using OrderPaymentSystem.Domain.Entities;

namespace OrderPaymentSystem.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);

        Task<Order?> GetByIdAsync(Guid id);

        Task<IEnumerable<Order>> GetAllAsync();

        Task SaveChangesAsync();
    }
}