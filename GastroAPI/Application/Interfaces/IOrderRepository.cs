using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddToOrderAsync(Product product, string name);
        Task<Order> GetOrderAsync(string name);
        Task<Order> CreateOrderAsync(Product product, string name);

        Task<Order> AddToOrderGroupAsync(Product product, string group);
        Task<Order> GetOrderGroupAsync(string group);
        Task<Order> CreateOrderGroupAsync(Product product, string group);
    }
}
