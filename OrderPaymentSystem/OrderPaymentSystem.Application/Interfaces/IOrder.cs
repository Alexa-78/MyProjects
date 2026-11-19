using OrderPaymentSystem.Application.DTOs;
using OrderPaymentSystem.Domain.Entities;

namespace OrderPaymentSystem.Application.Interfaces
{
    public interface IOrder
    {
        Task<Order?> CreateNewOrder(CreateOrderRequest orderItem, CancellationToken cancellationToken = default);
        Task<Order?> GetOrder(Guid orderId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Order>> GetAllOrders(CancellationToken cancellationToken = default);
        Task<Order?> UpdateOrderStatus(Guid id, OrderStatus status, CancellationToken cancellationToken = default);

    }
}
