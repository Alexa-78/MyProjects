using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;

namespace GastroAPI.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroContext _context;
        
        public async Task<Order?> AddToOrderAsync(int productId, string name)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Name == name);
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            order.AddOrderedProducts(product);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderAsync(string name)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Name == name);

            return order;
        }

        public async Task<Order> CreateOrderAsync(int productId, string name)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            Order order = new Order();
            order.SetName(name);
            order.AddOrderedProducts(product);
            return order;
        }


        public async Task<Order?> AddToOrderGroupAsync(int productId, string group)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Group == group);
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            order.AddOrderedProducts(product);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Group == group);

            return order;
        }

        public async Task<Order> CreateOrderGroupAsync(int productId, string group)
        {
            Product product = _context.Products.FirstOrDefault(p => p.Id == productId);
            Order order = new Order();
            order.SetGroup(group);
            order.AddOrderedProducts(product);
            return order;
        }
    }
}
