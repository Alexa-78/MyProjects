using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace GastroAPI.Infrastructure.Entity_Framework_Core
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
