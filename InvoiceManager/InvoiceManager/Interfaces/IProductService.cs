using InvoiceManager.Models;

namespace InvoiceManager.Interfaces
{
    public interface IProductService
    {
        Task <List<Product>> GetAllAsync();
        Task SaveAsync(Product product);
        Task DeleteAsync(Product product);
        Task<int> CountAsync();
    }
}
