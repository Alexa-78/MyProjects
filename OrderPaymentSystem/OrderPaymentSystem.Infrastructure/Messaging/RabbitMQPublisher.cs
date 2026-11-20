
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace OrderPaymentSystem.Infrastructure.Messaging
{
    public class RabbitMQPublisher : IAsyncDisposable
    {
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;
        private readonly SemaphoreSlim _connectionLock = new(1, 1);

        public RabbitMQPublisher(IConfiguration configuration)
        {
            _factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"] ?? "localhost",
                //Port = configuration.GetValue<int>("RabbitMQ:Port", 5672),
                UserName = configuration["RabbitMQ:UserName"] ?? "guest",
                Password = configuration["RabbitMQ:Password"] ?? "guest",
                AutomaticRecoveryEnabled = true
            };
        }

        private async Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken)
        {
            if (_connection is { IsOpen: true })
                return _connection;

            await _connectionLock.WaitAsync(cancellationToken);

            try
            {
                if (_connection is not { IsOpen: true })
                {
                    _connection = await _factory.CreateConnectionAsync(
                        cancellationToken);
                }

                return _connection;
            }
            finally
            {
                _connectionLock.Release();
            }
        }

        public async Task PublishAsync(
            string eventType,
            string payload,
            CancellationToken cancellationToken = default)
        {
            var connection = await GetConnectionAsync(cancellationToken);

            var channelOptions = new CreateChannelOptions(
                publisherConfirmationsEnabled: true,
                publisherConfirmationTrackingEnabled: true);

            await using var channel = await connection.CreateChannelAsync(
                channelOptions,
                cancellationToken);

            await channel.ExchangeDeclareAsync(
                exchange: "orders",
                type: ExchangeType.Topic,
                durable: true,
                autoDelete: false,
                cancellationToken: cancellationToken);

            await channel.QueueDeclareAsync(
                queue: "orders.queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: cancellationToken);

            await channel.QueueBindAsync(
                queue: "orders.queue",
                exchange: "orders",
                routingKey: eventType,
                cancellationToken: cancellationToken);

            var body = Encoding.UTF8.GetBytes(payload);

            var properties = new BasicProperties
            {
                Persistent = true,
                ContentType = "application/json",
                Type = eventType
            };

            await channel.BasicPublishAsync(
                exchange: "orders",
                routingKey: eventType,
                mandatory: true,
                basicProperties: properties,
                body: body,
                cancellationToken: cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
                await _connection.DisposeAsync();

            _connectionLock.Dispose();
        }
    }
}
