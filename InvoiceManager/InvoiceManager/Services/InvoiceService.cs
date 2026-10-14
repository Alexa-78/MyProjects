using InvoiceManager.Data;
using InvoiceManager.Interfaces;
using InvoiceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly InvoiceContext _context;

        public InvoiceService(InvoiceContext context)
        {
            _context = context;
        }

        public Invoice CreateInvoice(Customer customer)
        {
            return new Invoice
            {
                InvoiceDate = DateTime.Now,
                InvoiceNumber = GenerateInvoiceNumber(),
                Customer = customer
            };
        }

        public void AddItem(Invoice invoice, Product product, decimal quantity)
        {
            invoice.Items.Add(new InvoiceItem
            {
                Product = product,
                Quantity = quantity,
                UnitPrice = product.Price
            });
        }

        public async Task SaveInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Items)
                    .ThenInclude(i => i.Product)
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }

        public decimal CalculateNet(Invoice invoice)
        {
            return invoice.Items.Sum(x => x.Total);
        }

        public decimal CalculateVat(Invoice invoice)
        {
            return CalculateNet(invoice) * 0.19m;
        }

        public decimal CalculateGross(Invoice invoice)
        {
            return CalculateNet(invoice) + CalculateVat(invoice);
        }

        public string GenerateInvoiceNumber()
        {
            return $"INV-{DateTime.Now:yyyy}-{DateTime.Now.Ticks % 10000:D4}";
        }
    }
}
