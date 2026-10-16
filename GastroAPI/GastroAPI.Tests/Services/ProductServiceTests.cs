using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;
using GastroAPI.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;
using GastroAPI.Infrastructure.Repository;

namespace GastroAPI.Tests.Services
{
    public class ProductServiceTests
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
        public async Task GetProductAsync_ReturnsCorrectProduct()
        {
            var context = await GetInMemoryDbContext();
            var repository = new ProductRepository(context);
            var service = new ProductService(repository);

            var result = await service.GetProductAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Beer", result.Name);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetProductAsync_CheckIfProductExists()
        {
            // Was passiert, wenn ein Produkt nicht gefunden wird?

            var context = await GetInMemoryDbContext();
            var repository = new ProductRepository(context);
            var service = new ProductService(repository);

            var result = await service.GetProductAsync(1000);

            Assert.Null(result);
        }
    }
}
