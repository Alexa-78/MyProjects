using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.DTOs
{
    public class AddToOrderRequest
    {
        public Product Product { get; set; }
        public string Name { get; set; }
    }
}
