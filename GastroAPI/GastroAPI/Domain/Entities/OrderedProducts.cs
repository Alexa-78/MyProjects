namespace GastroAPI.Domain.Entities
{
    public class OrderedProducts
    {
        public int Id { get; private set; }
        public int OrderId { get; private set; }  //wichtig da mehrere Produkte in einer Order sein können

        public int Number { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

        public OrderedProducts()
        {

        }
        public OrderedProducts(int orderid, int number, string name, decimal price)
        {
            OrderId = orderid;
            Number = number;
            Name = name;
            Price = price;
        }
    }
}
