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

            #region Task 03
            Console.WriteLine("\n--- Short Report ---");

            PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            // This Action prints a short report with product name and price.
            Console.WriteLine("\n--- Detailed Report ---");

            PrintReport(catalog, p => Console.WriteLine(  $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"  ));

            // We use the same PrintReport method but change the lambda to print more details.

            Console.WriteLine("\n--- Summary List ---");

            List<string> summary =  TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            // This lambda transforms each Product into a simple text summary.

            foreach (string item in summary)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("\n--- Price Labels ---");

            List<string> labels =
                TransformProducts(catalog,
                p => p.Price > 100 ? $"{p.Name}: Expensive!" : $"{p.Name}: Affordable");

            foreach (string item in labels)
            {
                Console.WriteLine(item);
            }
            // This lambda gives each product a price label depending on its price.

            Console.WriteLine("\n--- Low-Stock Alert ---");

            List<Product> lowStock = FilterProducts(catalog, p => p.Stock < 20);

            foreach (Product p in lowStock)
            {
                Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");
            }

            // This Predicate finds products with stock less than 20.
            
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

        static void PrintReport(List<Product> products, Action<Product> action)
        {
            foreach (Product product in products)
            {
                action(product);
            }
        }
        // Action<Product> is used because it takes a Product and performs an action without returning a value.

        static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            List<string> result = new List<string>();

            foreach (Product product in products)
            {
                result.Add(transform(product));
            }

            return result;
        }
        // Func<Product, string> is used because it takes a Product and returns a string.

        static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
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
        // Predicate<Product> is used to test a Product condition and return true or false.

    }
}
