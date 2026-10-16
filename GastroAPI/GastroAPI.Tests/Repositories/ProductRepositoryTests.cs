using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;
using GastroAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using GastroAPI.Infrastructure.Repository;

namespace GastroAPI.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private async Task<GastroContext> GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GastroContext>()
                .UseInMemoryDatabase(databaseName: "GastroDb_" + Guid.NewGuid())
                .Options;

            var context = new GastroContext(options);

            // Seed Daten
            context.Products.AddRange(new List<Product>
            {
                new Product(1001, "Beer", 2.90m),
                new Product(1002, "Wine", 4.90m)
            });

            await context.SaveChangesAsync();
            return context;
        }

        [Fact]
        public async Task CreateProductAsync_SaveProductCorrect()
        {
            // Wird ein Produkt korrekt gespeichert?

            var context = await GetInMemoryDbContext();
            var repository = new ProductRepository(context);

            Product product = new Product(1003, "Water", 3.40m);

            var result = await repository.CreateProductAsync(product);

            Assert.NotNull(result);
            Assert.Equal(1003, result.Number);
            Assert.Equal("Water", result.Name);
            Assert.Equal(3.40m, result.Price);
        }
    }
}
