using OrderAPI.Application.DTOs;

namespace OrderAPI.Domain.Entities
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

        public Order(CreateOrderRequest request)
        {
            CustomerMail = request.CustomerEmail;
            TotalAmount = request.TotalAmount;
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
