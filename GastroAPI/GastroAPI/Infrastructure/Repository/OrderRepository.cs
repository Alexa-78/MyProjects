using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GastroContext _context;

        public OrderRepository(GastroContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetOrderAsync(string name)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Name == name);
        }

        public async Task CreateOrderAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetOrderGroupAsync(string group)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Group == group);
        }

        public async Task CreateOrderGroupAsync(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
