using System;
using System.Timers;

namespace StockQuoteAlert
{
    class Program
    {
        private static Timer timer;
        static void Main(string[] args)
        {   
            // Console.WriteLine("Por favor, entre com o ativo a ser monitorado:");
            // var assetName = Console.ReadLine();

            // Console.WriteLine("Por favor, entre com o preço para venda:");
            // var sellPrice = Double.Parse(Console.ReadLine());

            // Console.WriteLine("Por favor, entre com o preço para compra:");
            // var buyPrice = Double.Parse(Console.ReadLine());

            // var asset = new Asset(assetName, sellPrice, buyPrice);

            // asset.checkSellOrBuy();
            
            setTimer();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
            Console.WriteLine("Bye World!");
        }

        private static void setTimer()
        {
            timer = new Timer(2000);
            timer.Elapsed += Print;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void Print(Object sender, ElapsedEventArgs e)
        {
            System.Console.WriteLine("oi");
        }
    }
}
