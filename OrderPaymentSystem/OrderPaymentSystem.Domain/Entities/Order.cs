namespace OrderPaymentSystem.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerMail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public Order()
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
            if (Status == OrderStatus.Paid)
            {
                throw new InvalidOperationException("Eine abgeschlossene Bestellung kann nicht geändert werden.");
            }

            Status = status;
        }

        public bool CheckOrderSum()
        {
            if (TotalAmount > 0)
                return true;
            else
                return false;
        }

        public void UpdateOrder(Order order)
        {
            CustomerMail = order.CustomerMail;
            TotalAmount = order.TotalAmount;
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
