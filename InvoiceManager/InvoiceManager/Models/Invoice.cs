namespace InvoiceManager.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Customer Customer { get; set; }
        public List<InvoiceItem> Items { get; set; } = new();

        public decimal NetTotal => Items.Sum(i => i.Total);
        public decimal Vat => NetTotal * 0.19m;
        public decimal GrossTotal => NetTotal + Vat;
    }
}
