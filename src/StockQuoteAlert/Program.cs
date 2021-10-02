using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

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
                var data = client.DownloadString(queryUri);
                System.Console.WriteLine(data);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
