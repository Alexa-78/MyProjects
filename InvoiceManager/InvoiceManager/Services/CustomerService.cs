using InvoiceManager.Data;
using InvoiceManager.Interfaces;
using InvoiceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly InvoiceContext _context;

        public CustomerService(InvoiceContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task <List<Customer>> GetAllAsync()
        {
            return await _context.Customers
                .OrderBy(c => c.Company)
                .ToListAsync();
        }

        public async Task SaveAsync(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
                _context.Customers.Update(customer);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
