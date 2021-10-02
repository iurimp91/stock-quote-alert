using System;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
            var asset = Console.ReadLine();
            var apiClient = new ApiClient(asset);
            
            var jsonData = apiClient.GetStockAssetData();
            var assetPrice = apiClient.GetStockAssetPrice(jsonData);
            System.Console.WriteLine(assetPrice);


            Console.WriteLine("Hello World!");
        }
    }
}
