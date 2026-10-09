namespace GastroAPI.Application.DTOs
{
    public class UpdateProductRequest
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
