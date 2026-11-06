using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Entities;

namespace OrderAPI.Infrastructure.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}
