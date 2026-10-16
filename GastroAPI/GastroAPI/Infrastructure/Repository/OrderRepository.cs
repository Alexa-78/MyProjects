using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;

namespace GastroAPI.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroContext _context;

        public OrderRepository(GastroContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderAsync(string name)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Name == name);

            return order;
        }

        public async Task CreateOrderAsync(Order order)
        {      
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderGroupAsync(string group)
        {
            Order order = _context.Orders.FirstOrDefault(o => o.Group == group);

            return order;
        }

        public async Task CreateOrderGroupAsync(Order order)
        {
            await _context.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
