using System.Net;
using Newtonsoft.Json.Linq;

namespace StockQuoteAlert
{
    public class ApiClient
    {
        public string queryUrl = "https://api.hgbrasil.com/finance/stock_price?key=f626405b&symbol=";
        private string stockAsset;
        public ApiClient(string stockAsset)
        {
            this.queryUrl = queryUrl + stockAsset.ToUpper();
            stockAsset = stockAsset.ToUpper();
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

            return dynamicObject.results.stockAsset.price;
        }
    }
}