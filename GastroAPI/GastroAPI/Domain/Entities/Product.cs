namespace GastroAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

        public Product(int number, string name, decimal price)
        {
            Number = number;
            Name = name;
            Price = price;
        }

        public void UpdateProduct(int number, string name, decimal price)
        {
            Number = number;
            Name = name;
            Price = price;
        }
    }
}
