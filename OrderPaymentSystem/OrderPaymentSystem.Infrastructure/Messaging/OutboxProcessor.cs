
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderPaymentSystem.Infrastructure.Data;

namespace OrderPaymentSystem.Infrastructure.Messaging
{
    public class OutboxProcessor
    {
        private readonly OrderContext _context;
        private readonly RabbitMQPublisher _publisher;
        private readonly ILogger<OutboxProcessor> _logger;

        public OutboxProcessor(
            OrderContext context,
            RabbitMQPublisher publisher,
            ILogger<OutboxProcessor> logger)
        {
            _context = context;
            _publisher = publisher;
            _logger = logger;
        }

        public async Task ProcessAsync(
            CancellationToken cancellationToken = default)
        {
            var messages = await _context.OutboxMessages
                .Where(m => m.ProcessedAt == null)
                .OrderBy(m => m.CreatedAt)
                .Take(20)
                .ToListAsync(cancellationToken);

            foreach (var message in messages)
            {
                try
                {
                    await _publisher.PublishAsync(
                        message.EventType,
                        message.Payload,
                        cancellationToken);

                    message.ProcessedAt = DateTime.UtcNow;
                    message.Error = null;

                    await _context.SaveChangesAsync(cancellationToken);

                    _logger.LogInformation(
                        "Outbox-Nachricht {MessageId} erfolgreich verarbeitet.",
                        message.Id);
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    message.Error = ex.Message;

                    await _context.SaveChangesAsync(cancellationToken);

                    _logger.LogError(
                        ex,
                        "Fehler bei der Verarbeitung der Outbox-Nachricht {MessageId}.",
                        message.Id);
                }
            }
        }
    }
}
