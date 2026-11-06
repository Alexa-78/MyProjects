using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Application.DTOs
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "E-Mail ist erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse")]
        public string CustomerEmail { get; set; } = string.Empty;

        [Range(0.01, 999999999, ErrorMessage = "Bestellsumme muss größer als 0 sein")]
        public decimal TotalAmount { get; set; }
    }
}
