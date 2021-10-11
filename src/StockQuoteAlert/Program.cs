using System;
using System.Globalization;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {   
            try
            {
                Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
                var assetName = Console.ReadLine();

                var assetData = ApiClient.GetAssetData(assetName);

                while(assetData.Contains("error"))
                {
                    System.Console.WriteLine("O ativo não existe. Por favor, tente novamente.");
                    assetName = Console.ReadLine();
                    assetData = ApiClient.GetAssetData(assetName);
                }

                Console.WriteLine("Por favor, entre com o preço para venda:");
                var sellPriceInput = Console.ReadLine();

                while(string.IsNullOrEmpty(sellPriceInput) || Double.Parse(sellPriceInput) <= 0)
                {
                    System.Console.WriteLine("O preço de venda não pode ser vazio, nem menor ou igual a zero. Por favor, tente novamente.");
                    sellPriceInput = Console.ReadLine();
                }

                double sellPrice;

                if (sellPriceInput.Contains("."))
                {
                    sellPrice = Double.Parse(sellPriceInput, new CultureInfo("en-US"));
                }
                else
                {
                    sellPrice = Double.Parse(sellPriceInput);
                }

                Console.WriteLine("Por favor, entre com o preço para compra:");
                var buyPriceInput = Console.ReadLine();

                while(string.IsNullOrEmpty(buyPriceInput) || Double.Parse(buyPriceInput) <= 0 || Double.Parse(buyPriceInput) == sellPrice)
                {
                    System.Console.WriteLine("O preço de compra não pode ser vazio, nem menor ou igual a zero e nem igual ao preço de compra. Por favor, tente novamente.");
                    buyPriceInput = Console.ReadLine();
                }

                double buyPrice;

                if (buyPriceInput.Contains("."))
                {
                    buyPrice = Double.Parse(buyPriceInput, new CultureInfo("en-US"));
                }
                else
                {
                    buyPrice = Double.Parse(buyPriceInput);
                }

                var asset = new Asset(assetName, sellPrice, buyPrice);
                
                asset.StartMonitoring();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Para fechar a aplicação aperte ENTER.");
            Console.ReadLine();
        }
    }
}
