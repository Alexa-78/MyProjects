namespace OrderPaymentSystem.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerMail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        private Order()
        {

        }

        public Order(string customerMail, decimal totalAmount)
        {
            Id = Guid.NewGuid();
            CustomerMail = customerMail;
            TotalAmount = totalAmount;
            Status = OrderStatus.Created;
            CreatedAt = DateTime.UtcNow;
        }

        
        public void SetOrderStatus(OrderStatus status)
        {
            if (Status == OrderStatus.Paid ||
            Status == OrderStatus.Shipped ||
            Status == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException("Diese Bestellung kann nicht mehr geändert werden.");
            }

            Status = status;
        }

        public bool CheckOrderSum()
        {
            return TotalAmount > 0;
        }

        public void UpdateOrder(string customerMail, decimal totalAmount)
        {
            if (Status != OrderStatus.Created)
                throw new InvalidOperationException("Nur neue Bestellungen können geändert werden.");

            if (string.IsNullOrWhiteSpace(customerMail))
                throw new ArgumentException("CustomerMail darf nicht leer sein.");

            if (totalAmount <= 0)
                throw new ArgumentException("Der Bestellbetrag muss größer als 0 sein.");

            CustomerMail = customerMail;
            TotalAmount = totalAmount;
        }

    }

    public enum OrderStatus 
    {
        Created,
        Paid,
        Shipped,
        Cancelled
    }
}
