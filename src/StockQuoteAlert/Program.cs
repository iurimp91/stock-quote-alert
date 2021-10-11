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
                    assetName = InputHandler.GetAndValidateAssetName(assetNameInput);
                    if (assetName.Length != 0) break;
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            
            Console.WriteLine("Por favor, entre com o preço para venda:");
            var sellPrice = InputHandler.GetAndValidatePrice();

            Console.WriteLine("Por favor, entre com o preço para compra:");
            var buyPrice = InputHandler.GetAndValidatePrice(sellPrice);

            var asset = new Asset(assetName, sellPrice, buyPrice);
            
            asset.StartMonitoring();

            
            Console.WriteLine("Para fechar a aplicação aperte ENTER.");
            Console.ReadLine();
           
        }
    }
}
