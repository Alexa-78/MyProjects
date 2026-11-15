
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentService.Application.Events;
using PaymentService.Application.Payments;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace PaymentService.Infrastructure.Messaging;

public sealed class OrderCreatedConsumer : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<OrderCreatedConsumer> _logger;
    private readonly IConfiguration _configuration;

    private const string QueueName = "order-created";

    public OrderCreatedConsumer(IServiceScopeFactory scopeFactory, ILogger<OrderCreatedConsumer> logger, IConfiguration configuration)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMQ:Host"] ?? "localhost",
            UserName = _configuration["RabbitMQ:Username"] ?? "guest",
            Password = _configuration["RabbitMQ:Password"] ?? "guest"
        };

        await using var connection = await factory.CreateConnectionAsync(stoppingToken);

        await using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

        // Nachrichten einzeln verarbeiten
        await channel.BasicQosAsync(
            prefetchSize: 0,
            prefetchCount: 1,
            global: false,
            cancellationToken: stoppingToken);

        // Queue erstellen
        await channel.QueueDeclareAsync(
            queue: QueueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: stoppingToken);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            try
            {
                // 1. RabbitMQ-Nachricht lesen
                var json = Encoding.UTF8.GetString(
                    eventArgs.Body.ToArray());

                var orderEvent =
                    JsonSerializer.Deserialize<OrderCreatedEvent>(
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (orderEvent is null)
                {
                    _logger.LogWarning("Invalid OrderCreatedEvent received.");

                    await channel.BasicRejectAsync(
                        eventArgs.DeliveryTag,
                        requeue: false,
                        cancellationToken: stoppingToken);

                    return;
                }

                // 2. DI-Scope pro Nachricht erstellen
                await using var scope = _scopeFactory.CreateAsyncScope();

                var handler = scope.ServiceProvider.GetRequiredService<ProcessOrderPaymentHandler>();

                // 3. Application-Handler aufrufen
                await handler.HandleAsync(orderEvent, stoppingToken);

                // 4. Nachricht bestätigen
                // Gilt auch für bereits verarbeitete Events.
                await channel.BasicAckAsync(
                    eventArgs.DeliveryTag,
                    multiple: false,
                    cancellationToken: stoppingToken);

                _logger.LogInformation("OrderCreatedEvent {EventId} processed.", orderEvent.EventId);
            }
            catch (JsonException ex)
            {
                // Ungültiges JSON: nicht erneut zustellen
                _logger.LogWarning(ex, "Invalid JSON received.");

                await channel.BasicRejectAsync(
                    eventArgs.DeliveryTag,
                    requeue: false,
                    cancellationToken: stoppingToken);
            }
            catch (ArgumentException ex)
            {
                // Ungültige Nachricht: nicht erneut zustellen
                _logger.LogWarning(
                    ex,
                    "Invalid order event. Rejecting message.");

                await channel.BasicRejectAsync(
                    eventArgs.DeliveryTag,
                    requeue: false,
                    cancellationToken: stoppingToken);
            }
            catch (OperationCanceledException)
                when (stoppingToken.IsCancellationRequested)
            {
                // Beim Herunterfahren nicht bestätigen.
                // Die nicht bestätigte Nachricht kann erneut zugestellt werden.
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error processing OrderCreatedEvent.");

                // Temporärer Fehler: erneut zustellen
                await channel.BasicNackAsync(
                    eventArgs.DeliveryTag,
                    multiple: false,
                    requeue: true,
                    cancellationToken: stoppingToken);
            }
        };

        // 5. Consumer starten
        await channel.BasicConsumeAsync(
            queue: QueueName,
            autoAck: false,
            consumer: consumer,
            cancellationToken: stoppingToken);

        _logger.LogInformation("RabbitMQ Consumer started. Queue: {QueueName}", QueueName);

        // Consumer am Leben halten
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
