namespace GastroAPI.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(int number, string name, decimal price)
        {
            Number = number;
            Name = name;
            Price = price;

            // nur vorläufiges Beispiel
            // liste wird aus DB übernommen und dort die Produkte auch eingetragen
            // wird in ProductService normal eingebaut
            List<Product> products = new List<Product> 
            {
                new Product(1, "Wine", 2.90m),
                new Product(2, "Cocktail", 4.40m),
                new Product(2, "Cocktail", 4.40m),
                new Product(14, "Sandwich", 2.40m),
            };

            // ausgabe mit Linq, vorläufiges Beispiel muss woanders eingebaut werden

            Product prod = products.FirstOrDefault(p => p.Name == name);
        }
    }
}
