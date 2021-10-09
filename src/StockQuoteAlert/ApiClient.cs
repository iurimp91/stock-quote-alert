using System.Net;

namespace StockQuoteAlert
{
    public class ApiClient
    {
        private string queryUrl = "https://api.hgbrasil.com/finance/stock_price?key=f626405b&symbol=";
        private string assetName;
        public ApiClient(string assetName)
        {
            this.queryUrl = queryUrl + assetName;
            this.assetName = assetName;
        }

        public string GetAssetData()
        {
            dynamic json_data;

            using (WebClient client = new WebClient())
            {   
                json_data = client.DownloadString(queryUrl);
            }

            return json_data;
        }
    }
}