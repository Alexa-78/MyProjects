using PaymentService.Domain.Entities;

namespace PaymentService.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<bool> SavePaymentAsync(Payment payment, Guid eventId, CancellationToken cancellationToken);
    }
}
