using GastroAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GastroAPI.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product?> UpdateProductAsync(int id, Product product);

        Task<bool> DeleteProductAsync(int id);
    }
}
