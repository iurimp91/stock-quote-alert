using System;
using Newtonsoft.Json.Linq;

namespace StockQuoteAlert
{
    public class Asset : ApiClient
    {
        private string assetName;
        public double currentPrice;
        private double sellPrice;
        private double buyPrice; 
        public Asset(string assetName, double sellPrice, double buyPrice) : base(assetName)
        {
            this.assetName = assetName.ToUpper();
            this.sellPrice = sellPrice;
            this.buyPrice = buyPrice;
        }

        public void setCurrentPrice()
        {
            var assetData = GetAssetData();
            dynamic dynamicObject = JObject.Parse(assetData);
            
            currentPrice = dynamicObject.results[assetName].price;
        }

        public void checkSellOrBuy()
        {   
            setCurrentPrice();
            Console.WriteLine($"O preço atual é {currentPrice}");
            if (currentPrice >= sellPrice)
            {
                System.Console.WriteLine("Venda!");
            } else if (currentPrice <= buyPrice)
            {
                System.Console.WriteLine("Compra!");
            }
        }
    }
}