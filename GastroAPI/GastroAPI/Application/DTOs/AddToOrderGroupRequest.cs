using GastroAPI.Domain.Entities;

namespace GastroAPI.Application.DTOs
{
    public class AddToOrderGroupRequest
    {
        public int ProductId { get; set; }
        public string Group { get; set; }
    }
}
