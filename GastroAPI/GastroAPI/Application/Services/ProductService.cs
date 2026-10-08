using GastroAPI.Application.Interfaces;
using GastroAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GastroAPI.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _repository.GetProductAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException(
                    "Der Produktname darf nicht leer sein.");

            if (product.Price < 0)
                throw new ArgumentException(
                    "Der Preis darf nicht negativ sein.");

            return await _repository.CreateProductAsync(product);
        }

        public async Task<Product?> UpdateProductAsync(int id, Product product)
        {
            return await _repository.UpdateProductAsync(id, product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _repository.DeleteProductAsync(id);
        }
    }
}
