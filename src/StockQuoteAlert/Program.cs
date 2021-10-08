using System;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
            var asset = Console.ReadLine();

            Console.WriteLine("Por favor, entre com o preço para venda:");
            var sellPrice = Double.Parse(Console.ReadLine());

            Console.WriteLine("Por favor, entre com o preço para compra:");
            var buyPrice = Double.Parse(Console.ReadLine());


            var apiClient = new ApiClient(asset, sellPrice, buyPrice);

            Console.WriteLine("Hello World!");
        }
    }
}
