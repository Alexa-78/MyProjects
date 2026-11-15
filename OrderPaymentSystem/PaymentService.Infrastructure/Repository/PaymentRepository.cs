using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PaymentService.Application.Interfaces;
using PaymentService.Domain.Entities;
using PaymentService.Infrastructure.Data;

namespace PaymentService.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public async Task<bool> IsEventProcessedAsync(
            Guid eventId,
            CancellationToken cancellationToken)
        {
            return await _context.ProcessedEvents
                .AnyAsync(x => x.EventId == eventId,
                    cancellationToken);
        }

        public async Task<bool> SavePaymentAsync(
            Payment payment,
            Guid eventId,
            CancellationToken cancellationToken)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync(
                    cancellationToken);

            try
            {
                // Event als verarbeitet registrieren
                _context.ProcessedEvents.Add(new ProcessedEvent
                {
                    EventId = eventId,
                    ProcessedAt = DateTime.UtcNow
                });

                // Zahlung speichern
                _context.Payments.Add(payment);

                // Beide Änderungen gemeinsam speichern
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return true;
            }
            catch (DbUpdateException ex)
                when (IsUniqueConstraintViolation(ex))
            {
                await transaction.RollbackAsync(cancellationToken);

                return false;
            }
        }

        private static bool IsUniqueConstraintViolation(
            DbUpdateException exception)
        {
            return exception.InnerException is SqlException sqlException
                && (sqlException.Number == 2601
                    || sqlException.Number == 2627);
        }
    }
}
