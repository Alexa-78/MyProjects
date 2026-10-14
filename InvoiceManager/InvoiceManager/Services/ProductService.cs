using InvoiceManager.Data;
using InvoiceManager.Interfaces;
using InvoiceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Services
{
    public class ProductService : IProductService
    {
        private readonly InvoiceContext _context;

        public ProductService(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task <List<Product>> GetAllAsync()
        {
            return await _context.Products
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task SaveAsync(Product product)
        {
            if (product.Id == 0)
                _context.Products.Add(product);
            else
                _context.Products.Update(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
