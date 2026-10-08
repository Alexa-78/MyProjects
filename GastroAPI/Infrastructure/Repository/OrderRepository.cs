using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;

namespace GastroAPI.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public async Task<Order?> AddToOrderAsync(Product product, string name)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Name == name);
            order.AddOrderedProducts(product);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderAsync(string name)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Name == name);

            return order;
        }

        public async Task<Order> CreateOrderAsync(Product product, string name)
        {
            Order order = new Order();
            order.SetName(name);
            order.AddOrderedProducts(product);
            return order;
        }


        public async Task<Order?> AddToOrderGroupAsync(Product product, string group)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Group == group);
            order.AddOrderedProducts(product);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Group == group);

            return order;
        }

        public async Task<Order> CreateOrderGroupAsync(Product product, string group)
        {
            Order order = new Order();
            order.SetGroup(group);
            order.AddOrderedProducts(product);
            return order;
        }
    }
}
