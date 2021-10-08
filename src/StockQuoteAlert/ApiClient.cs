using System.Net;
using Newtonsoft.Json.Linq;

namespace StockQuoteAlert
{
    public class ApiClient
    {
        public string queryUrl = "https://api.hgbrasil.com/finance/stock_price?key=f626405b&symbol=";
        private string stockAsset;
        public double currentPrice;
        private double sellPrice;
        private double buyPrice; 
        public ApiClient(string stockAsset, double sellPrice, double buyPrice)
        {
            this.queryUrl = queryUrl + stockAsset.ToUpper();
            this.stockAsset = stockAsset.ToUpper();
            this.sellPrice = sellPrice;
            this.buyPrice = buyPrice;
        }

        public string GetStockAssetData()
        {
            dynamic json_data;

            using (WebClient client = new WebClient())
            {   
                json_data = client.DownloadString(queryUrl);
            }

            return json_data;
        }

        public double GetStockAssetPrice(string stockAssetData)
        {
            dynamic dynamicObject = JObject.Parse(stockAssetData);
            var assetName = stockAsset;

            return dynamicObject.results[assetName].price;
        }
    }
}