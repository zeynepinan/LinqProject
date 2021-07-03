using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{ CategoryId=1,CategoryName="Bilgisayar"},
                new Category{ CategoryId=2,CategoryName="Telefon"}

            };

            List<Product> products = new List<Product>
            {
                new Product{ ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB Ram", UnitPrice=6000, UnitsInStock=10},
                new Product{ ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB Ram", UnitPrice=7000,UnitsInStock=5},
                new Product{ ProductId=3,CategoryId=1,ProductName="HP Laptop",QuantityPerUnit="8 GB Ram", UnitPrice=9000,UnitsInStock=8},
                new Product{ ProductId=4,CategoryId=2,ProductName="Samsung Telefon",QuantityPerUnit="4 GB Ram", UnitPrice=3000,UnitsInStock=3},
                new Product{ ProductId=5,CategoryId=2,ProductName="Apple Telefon",QuantityPerUnit="4 GB Ram", UnitPrice=8000,UnitsInStock=0},

            };
            //Test(products);
            //GetProducts(products);


            //AnyTest(products);


            // FindTest(products);

            //FindAllTest(products);

            //AscDescTest(products);

            //ClassicLinqTest(products);


        }

        private static void ClassicLinqTest(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice <= 7000
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void AscDescTest(List<Product> products)
        {
            //Single Line Query
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void FindAllTest(List<Product> products)
        {
            // where ile aynı şekilde çalışır. Where koşulu IEnumerable list döner.
            // FindAll normal bir list döner.
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void FindTest(List<Product> products)
        {
            // İlgili id nin detay bilgilerini isterken kullanabiliriz.
            // Mesela id'si 1 olan ürünün detaylarını bulur.
            
            var result = products.Find(p => p.ProductId == 1);
            Console.WriteLine(result.ProductName);
        }

        private static void AnyTest(List<Product> products)
        {
            // Listenin içinde eleman var mı yok mu?
            var result = products.Any(p => p.ProductName == "Acer Laptop");
            Console.WriteLine(result);
        }

        private static void Test(List<Product> products)
        {
            Console.WriteLine("ALGORİTMİK");
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    Console.WriteLine(product.ProductName);
                }
            }

            Console.WriteLine("LINQ ");

            var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);

            foreach (var product in result)
            {

                Console.WriteLine(product.ProductName);

            }
        }

        //ALGORİTMİK OLARAK YAZIM
        static List<Product> GetProducts(List<Product> products) 
        {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
                {
                    filteredProducts.Add(product);
                }
            }
            return filteredProducts;
        }

        //LINQ İLE YAZIM
        static List<Product> GetProductsLinq(List<Product> products)
        {
            return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();

        }
    }

    internal class ProductDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
    }

    class Product 
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
