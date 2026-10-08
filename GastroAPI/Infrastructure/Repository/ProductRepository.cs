using GastroAPI.Application.Interfaces;
using GastroAPI.Infrastructure.Entity_Framework_Core;
using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (prod != null)
            {
                //bk.Title = product.Title;
                //bk.Description = product.Description;
                await _context.SaveChangesAsync();

                return product;
            }

            return null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(b => b.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
