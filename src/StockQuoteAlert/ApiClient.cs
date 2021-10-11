using System.Net;

namespace StockQuoteAlert
{
    public class ApiClient
    {
        private static string queryUrl = "https://api.hgbrasil.com/finance/stock_price?key=f626405b&symbol=";

        public static string GetAssetData(string assetName)
        {
            dynamic json_data;

            using (WebClient client = new WebClient())
            {   
                json_data = client.DownloadString(queryUrl + assetName);
            }

            return json_data;
        }
    }
}