using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace StockQuoteAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            string QUERY_URL = "https://api.hgbrasil.com/finance/stock_price?key=f626405b&symbol=bidi4";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {   
                dynamic json_data = client.DownloadString(queryUri);
                dynamic oi =  JObject.Parse(json_data);
                System.Console.WriteLine(oi.by);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
