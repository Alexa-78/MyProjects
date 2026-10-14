namespace InvoiceManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ArticleNumber { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public decimal VatRate { get; set; } = 19m;

        public bool IsActive { get; set; } = true;
    }
}
