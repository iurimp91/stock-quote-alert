using System;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiClient = new ApiClient("petr4");
            
            var jsonData = apiClient.GetStockAssetData();
            var assetPrice = apiClient.GetStockAssetPrice(jsonData);
            System.Console.WriteLine(assetPrice);


            Console.WriteLine("Hello World!");
        }
    }
}
