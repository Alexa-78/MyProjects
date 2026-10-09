using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddToOrderAsync(int productId, string name);
        Task<Order> GetOrderAsync(string name);
        Task<Order> CreateOrderAsync(int productId, string name);

        Task<Order> AddToOrderGroupAsync(int productId, string group);
        Task<Order> GetOrderGroupAsync(string group);
        Task<Order> CreateOrderGroupAsync(int productId, string group);
    }
}
