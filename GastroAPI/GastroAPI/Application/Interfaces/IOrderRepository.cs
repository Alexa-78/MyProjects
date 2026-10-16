using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderAsync(string name);
        Task CreateOrderAsync(Order order);

        Task<Order?> GetOrderGroupAsync(string group);
        Task CreateOrderGroupAsync(Order order);
    }
}
