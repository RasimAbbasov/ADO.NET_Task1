using ADO.NET_Task1.Services;

namespace ADO.NET_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //ProductService productservice = new ProductService();
            //productservice.Create(new() { Name = "Product2", Price = 25.99m });
            //foreach (var product in productservice.ReadAll())
                //Console.WriteLine(product);
           ProductDetailsService productdetailsservice = new ProductDetailsService();
            productdetailsservice.Create(new() { Quantity = "salam", ProductLink = "salam",ProductId=3});

        }
    }
}
