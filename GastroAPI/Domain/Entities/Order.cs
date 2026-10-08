namespace GastroAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Group { get; private set; } //eg table or umbrella

        private List<Product> OrderedProducts { get; set; } = new();

        public Order()
        {
            Name = "";
            Group = "";
        }
        public void SetName(string name) 
        {
            Name = name;
            Group = "";
        }

        public void SetGroup(string group)
        {
            Name = "";
            Group = group;
        }

        public void AddOrderedProducts(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            OrderedProducts.Add(product);
        }
    }
}
