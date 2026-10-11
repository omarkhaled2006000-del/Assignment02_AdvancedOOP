using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

}
public class Program
{
    static List<Product> FilterProducts(
        List<Product> products,
        Predicate<Product> condition)
    {
        List<Product> result = new List<Product>();

        foreach (Product p in products)
        {
            if (condition(p))
            {
                result.Add(p);
            }
        }

        return result;
    }

    static List<string> TransformProducts (List<Product> products, Func<Product, string> transform)
    {
        List<string> result = new List<string>();
        foreach (Product product in products)
        {
            result.Add(transform(product));
        }
        return result;
    }
    static void PrintProducts(List<Product> products,  Action<Product> printAction)
    {
            foreach(Product p in products)
        {
            printAction(p);
        }
            
                
            
        
    }
    static List<Product> SearchProducts(
    List<Product> products,
    Func<Product, bool> filter)
    {
        List<Product> result = new List<Product>();

        foreach (Product product in products)
        {
            if (filter(product))
            {
                result.Add(product);
            }
        }

        return result;
    }
    static void Main(string[] args)
    {
        List<Product> products = new()
{
    new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
    new Product { Id=2,Name="Phone", Category="Electronics", Price=800, Stock=25 },
    new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
    new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
    new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
    new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
    new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
    new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
    new Product { Id=9,Name="Headphones", Category="Electronics", Price=150, Stock=40 },
    new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
};

        Console.WriteLine("========= Electronics =========");
        List<Product> electronics = new List<Product>();
        electronics = SearchProducts(products, p => p.Category == "Electronics");
        foreach(Product p in electronics)
        {
            Console.WriteLine($" {p.Name} - ${p.Price}(Stock : {p.Stock})");
        }

        Console.WriteLine("========= Products cheaper than 50$ =========");
        List<Product> CheapProducts = SearchProducts(products, p => p.Price < 50);
        foreach(Product p in CheapProducts)
        {
            Console.WriteLine($" {p.Name} - ${p.Price}(Stock : {p.Stock})");
        }

        Console.WriteLine("========= Products in Stock =========");
        List<Product> ProductsinStock = SearchProducts(products, p => p.Stock > 0);
        foreach (Product p in ProductsinStock)
        {
            Console.WriteLine($" {p.Name} - ${p.Price}(Stock : {p.Stock})");
        }

        Console.WriteLine("========= Clothing Products under 100$ =========");
        List<Product> ClothingProducts = SearchProducts(products, p => p.Category == "Clothing" && p.Price < 100);
        foreach (Product p in ClothingProducts)
        {
            Console.WriteLine($" {p.Name} - ${p.Price}(Stock : {p.Stock})");
        }

        Console.WriteLine("========= Short Report =========");
        PrintProducts(products, p => Console.WriteLine($" {p.Name} - {p.Price}"));

        Console.WriteLine("========= Detailed Report =========");
        PrintProducts(products, p => Console.WriteLine($" [{p.Category}] {p.Name} | Price : ${p.Price} | Stock: {p.Stock}"));


        

        Console.WriteLine("\n=== Product Summaries ===");
        List<string> summaries = TransformProducts(
            products,
            p => p.Name + " ($" + p.Price + ")");

        foreach (string summary in summaries)
        {
            Console.WriteLine(summary);
        }

        Console.WriteLine("\n=== Product Price Labels ===");
        List<string> priceLabels = TransformProducts(
            products,
            p => p.Name + ": " +
                 (p.Price > 100 ? "Expensive!" : "Affordable"));

        foreach (string label in priceLabels)
        {
            Console.WriteLine(label);
        }

        Console.WriteLine("\n=== Low Stock Products ===");
        List<Product> lowStock = FilterProducts(
            products, p => p.Stock < 20);

        foreach (Product p in lowStock)
        {
            Console.WriteLine(
                "[LOW STOCK] " + p.Name +
                ": only " + p.Stock + " left!");
        }

    }
               
}
