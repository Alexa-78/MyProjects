using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Infrastructure.Entity_Framework_Core
{
    public class GastroContext : DbContext
    {
        public GastroContext(DbContextOptions<GastroContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
