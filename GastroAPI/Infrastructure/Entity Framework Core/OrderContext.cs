using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Infrastructure.Entity_Framework_Core
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
           : base(options)
        { }
        public DbSet<Order> Orders { get; set; }
    }
}
