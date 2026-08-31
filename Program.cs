namespace C_Advanced02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 01
            List<Product> catalog = new List<Product>()
                    {
                        new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },

                        new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },

                        new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },

                        new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },

                        new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },

                        new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },

                        new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },

                        new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },

                        new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },

                        new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
                    };
            Console.WriteLine("--- Electronics ---");
            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");
            // This lambda filters products whose category is Electronics.
            // It takes a Product object p and checks if its Category property is equal to "Electronics".
            foreach (Product p in electronics)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }


            Console.WriteLine("\n--- Under $50 ---");

            List<Product> under50 =  SearchProducts(catalog, p => p.Price < 50);

            foreach (Product p in under50)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            // This lambda filters products with a price less than 50.
            // It takes a Product object p and checks if its Price property is less than 50.
            //nfs ely 3mlnaah fo2 mghyrnash haga

            Console.WriteLine("\n--- In Stock ---");

            List<Product> inStock =  SearchProducts(catalog, p => p.Stock > 0);

            foreach (Product p in inStock)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            // This lambda checks if the product is available in stock.

            Console.WriteLine("\n--- Clothing Under $100 ---");

            List<Product> clothing = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            foreach (Product p in clothing)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            // This lambda checks two conditions: Clothing category and price under 100.

            #endregion
        }


        //Task 01
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> condition)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (condition(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        // Func<Product, bool> is used because it takes a Product and returns true or false.
    }
}
