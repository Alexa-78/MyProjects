using InvoiceManager.Data;
using InvoiceManager.Models;


namespace InvoiceManager.Interfaces
{
    public interface IInvoiceService
    {
        public Invoice CreateInvoice(Customer customer);
        public void AddItem(Invoice invoice, Product product, decimal quantity);
        Task SaveInvoiceAsync(Invoice invoice);

        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice?> GetInvoiceAsync(int id);
        Task DeleteInvoiceAsync(int id);
        public decimal CalculateNet(Invoice invoice);
        public decimal CalculateVat(Invoice invoice);
        public decimal CalculateGross(Invoice invoice);
        public string GenerateInvoiceNumber();
        
    }
}
