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

            if (currentPrice >= sellPrice)
            {
                Console.WriteLine($"O preço atual do ativo {assetName} é {currentPrice} e o valor de venda, {sellPrice}, foi atingido.");
                System.Console.WriteLine("E-mail enviado! Caso queira monitorar novamente, reinicie a aplicação.");
                EmailClient.SendEmail("[VENDA] Seu ativo atingiu o valor de venda.", timer);
                Environment.Exit(0);
            }
            else if (currentPrice <= buyPrice)
            {
                Console.WriteLine($"O preço atual do ativo {assetName} é {currentPrice} e o valor de compra, {buyPrice}, foi atingido.");
                System.Console.WriteLine("E-mail enviado! Caso queira monitorar novamente, reinicie a aplicação.");
                EmailClient.SendEmail("[COMPRA] Seu ativo atingiu o valor de compra.", timer);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"O preço atual do ativo {assetName} é {currentPrice}. Valor para venda: {sellPrice}. Valor para compra: {buyPrice}.");
                Console.WriteLine("Monitorando...");    
            }
        }
        
        public void StartMonitoring()
        {
            timer = new Timer(5000);
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