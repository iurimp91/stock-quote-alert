using System;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            string assetNameInput;
            string assetName;
            while(true)
            {
                Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
                assetNameInput = Console.ReadLine();
                
                try
                {
                    assetName = InputHandler.ValidateAssetName(assetNameInput);
                    break;
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            string sellPriceInput;
            double sellPrice;
            while(true)
            {
                Console.WriteLine("Por favor, entre com o preço para venda:");
                sellPriceInput = Console.ReadLine();
                
                try
                {
                    sellPrice = InputHandler.ValidatePrice(sellPriceInput);
                    break;
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            string buyPriceInput;
            double buyPrice;
            while(true)
            {
                Console.WriteLine("Por favor, entre com o preço para compra:");
                buyPriceInput = Console.ReadLine();
                
                try
                {
                    buyPrice = InputHandler.ValidatePrice(buyPriceInput, sellPrice);
                    break;
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }

            var asset = new Asset(assetName, sellPrice, buyPrice);
            
            asset.StartMonitoring();
            
            Console.WriteLine("Para fechar a aplicação aperte ENTER.");
            Console.ReadLine();
           
        }
    }
}
