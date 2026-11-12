using OrderPaymentSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderPaymentSystem.Application.DTOs
{
    public class UpdateOrderStatusRequest
    {
        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
    }
}
