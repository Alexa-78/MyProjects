using OrderAPI.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Application.DTOs
{
    public class UpdateOrderStatusRequest
    {
        [Required]
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
    }
}
