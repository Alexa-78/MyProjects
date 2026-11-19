using Microsoft.EntityFrameworkCore;
using OrderPaymentSystem.Application.Interfaces;
using OrderPaymentSystem.Domain.Entities;
using OrderPaymentSystem.Infrastructure.Data;
using OrderPaymentSystem.Infrastructure.Messaging;

namespace OrderPaymentSystem.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order order, CancellationToken cancellationToken = default)
        {
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return order;
        }

        public async Task<Order> CreateWithOutboxAsync(Order order, string eventType, string payload, CancellationToken cancellationToken = default)
        {
            var outboxMessage = new OutboxMessage
            {
                Id = Guid.NewGuid(),
                EventType = eventType,
                Payload = payload,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Orders.AddAsync(order, cancellationToken);

            await _context.OutboxMessages.AddAsync(
                outboxMessage,
                cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return order;
        }

        public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}