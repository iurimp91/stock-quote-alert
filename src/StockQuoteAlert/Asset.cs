using System.Net;
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

        public double setCurrentPrice()
        {
            var assetData = GetAssetData();
            dynamic dynamicObject = JObject.Parse(assetData);

            return dynamicObject.results[assetName].price;
        }
    }
}