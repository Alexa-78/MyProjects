using InvoiceManager.Models;

namespace InvoiceManager.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();
        Task SaveAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<int> CountAsync();
    }
}
