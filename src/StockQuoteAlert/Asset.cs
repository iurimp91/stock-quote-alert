using System;
using System.Timers;
using Newtonsoft.Json.Linq;

namespace StockQuoteAlert
{
    public class Asset : ApiClient
    {
        private string assetName;
        public double currentPrice;
        readonly double sellPrice;
        readonly double buyPrice;
        private static Timer timer;
        public Asset(string assetName, double sellPrice, double buyPrice) : base(assetName)
        {
            this.assetName = assetName.ToUpper();
            this.sellPrice = sellPrice;
            this.buyPrice = buyPrice;
        }

        private void SetCurrentPrice()
        {
            var assetData = GetAssetData();
            dynamic dynamicObject = JObject.Parse(assetData);
            
            currentPrice = dynamicObject.results[assetName].price;
        }

        private void CheckSellOrBuy()
        {   
            SetCurrentPrice();
            Console.WriteLine($"O preço atual é {currentPrice}");
            if (currentPrice >= sellPrice)
            {
                System.Console.WriteLine("Venda!");
            } else if (currentPrice <= buyPrice)
            {
                System.Console.WriteLine("Compra!");
            }
        }
        
        public void StartMonitoring()
        {
            timer = new Timer(2000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object sender, ElapsedEventArgs e)
        {
            CheckSellOrBuy();
        }
    }
}