using Azure.Core;
using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using GastroAPI.Infrastructure.Entity_Framework_Core;

namespace GastroAPI.Infrastructure.Repository
{
    public class OrderedProductsRepository : IOrderedProductsRepository 
    {
        private readonly GastroContext _context;

        public OrderedProductsRepository(GastroContext context)
        {
            _context = context;
        }

        public async Task<OrderedProducts> AddProductAsync(OrderedProducts orderedproduct)
        {
            ArgumentNullException.ThrowIfNull(orderedproduct);

            _context.OrderedProducts.Add(orderedproduct);
            await _context.SaveChangesAsync();
            return orderedproduct;
        }
    }
}
