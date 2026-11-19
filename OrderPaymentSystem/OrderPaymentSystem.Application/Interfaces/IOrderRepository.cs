using OrderPaymentSystem.Domain.Entities;

namespace OrderPaymentSystem.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default);

        Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}