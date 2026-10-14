namespace InvoiceManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
