namespace GastroAPI.Application.DTOs
{
    public class CreateProductRequest
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
