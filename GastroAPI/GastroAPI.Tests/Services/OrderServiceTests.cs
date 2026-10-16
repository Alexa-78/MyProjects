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
    public class OrderServiceTests
    {
        private async Task<GastroContext> GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<GastroContext>()
                .UseInMemoryDatabase(databaseName: "GastroDb_" + Guid.NewGuid())
                .Options;

            var context = new GastroContext(options);

            // Seed Daten
            var order1 = new Order();
            order1.SetName("Alex");

            var order2 = new Order();
            order2.SetGroup("Table1");

            context.Orders.AddRange(order1, order2);

            var product = new Product(1001, "Beer", 2.90m);
            context.Products.Add(product);

            await context.SaveChangesAsync();
            return context;
        }

        [Fact]
        public async Task CreateOrderAsync_CreateOrderCorrect()
        {
            // Wird eine Bestellung korrekt erstellt?

            var context = await GetInMemoryDbContext();
            var orderRepository = new OrderRepository(context);
            var orderProductsRepository = new OrderedProductsRepository(context);
            var productRepository = new ProductRepository(context);
            var service = new OrderService(orderRepository, orderProductsRepository, productRepository);

            Order order = new Order();
            order.SetName("Stefan");

            var product = await context.Products.FirstAsync(p => p.Number == 1001);

            var result = await service.CreateOrderAsync(product.Id, order.Name);

            Assert.NotNull(result);
            Assert.Equal("Stefan", result.Name);

            var savedOrder = await context.Orders.FirstOrDefaultAsync(o => o.Id == result.Id);

            Assert.NotNull(savedOrder);

            var savedProduct = await context.Set<OrderedProducts>()
                .FirstOrDefaultAsync(p =>
                    p.OrderId == result.Id &&
                    p.Number == product.Number);

            Assert.NotNull(savedProduct);
        }
    }
}
