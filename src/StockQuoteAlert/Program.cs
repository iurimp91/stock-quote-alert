using System;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {   
            try
            {
                Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
                var assetName = InputHandler.GetAndValidateAssetName();

                Console.WriteLine("Por favor, entre com o preço para venda:");
                var sellPrice = InputHandler.GetAndValidatePrice();

                Console.WriteLine("Por favor, entre com o preço para compra:");
                var buyPrice = InputHandler.GetAndValidatePrice(sellPrice);

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
