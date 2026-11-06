using OrderAPI.Application.DTOs;
using OrderAPI.Domain.Entities;

namespace OrderAPI.Application.Interfaces
{
    public interface IOrder
    {
        Task<Order?> CreateNewOrder(CreateOrderRequest orderItem);
        Task<Order?> GetOrder(Guid orderid);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order?> UpdateOrderStatus(OrderStatus status, Guid id);

    }
}
