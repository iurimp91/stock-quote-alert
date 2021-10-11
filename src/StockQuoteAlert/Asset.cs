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
        public Asset(string assetName, double sellPrice, double buyPrice)
        {
            this.assetName = assetName.ToUpper();
            this.sellPrice = sellPrice;
            this.buyPrice = buyPrice;
        }

        private void SetCurrentPrice()
        {
            var assetData = GetAssetData(assetName);
            dynamic dynamicObject = JObject.Parse(assetData);
            
            currentPrice = dynamicObject.results[assetName].price;
        }

        private void CheckSellOrBuy()
        {   
            SetCurrentPrice();
            Console.WriteLine($"O preço atual é {currentPrice}");
            if (currentPrice >= sellPrice)
            {
                System.Console.WriteLine("Valor de venda atingido, email enviado!");
                EmailClient.SendEmail("[VENDA] Seu ativo atingiu o valor de venda.", timer);            } else if (currentPrice <= buyPrice)
            {
                System.Console.WriteLine("Valor de compra atingido, email enviado!");
                EmailClient.SendEmail("[COMPRA] Seu ativo atingiu o valor de compra.", timer);
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