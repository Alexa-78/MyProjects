using Microsoft.EntityFrameworkCore;
using OrderPaymentSystem.Domain.Entities;

namespace OrderPaymentSystem.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}
