using System;
using System.Globalization;

namespace StockQuoteAlert
{
    public class InputHandler
    {
        public static string GetAndValidateAssetName(string assetName)
        {   
            var assetData = ApiClient.GetAssetData(assetName);

            if (assetData.Contains("error"))
            {
               throw new ArgumentException("Invalid asset"); 
            }

            return assetName;
        }

        public static double GetAndValidatePrice()
        {
            var sellPriceInput = Console.ReadLine();

            while(string.IsNullOrEmpty(sellPriceInput) || Double.Parse(sellPriceInput) <= 0)
            {
                System.Console.WriteLine("O preço de venda não pode ser vazio, nem menor ou igual a zero. Por favor, tente novamente.");
                sellPriceInput = Console.ReadLine();
            }

            return ConvertToDouble(sellPriceInput);
        }

        public static double GetAndValidatePrice(double sellPrice)
        {
            var buyPriceInput = Console.ReadLine();

            while(string.IsNullOrEmpty(buyPriceInput) || Double.Parse(buyPriceInput) <= 0 || Double.Parse(buyPriceInput) == sellPrice)
            {
                System.Console.WriteLine("O preço de compra não pode ser vazio, nem menor ou igual a zero e nem igual ao preço de compra. Por favor, tente novamente.");
                buyPriceInput = Console.ReadLine();
            }

            return ConvertToDouble(buyPriceInput);
        }

        private static double ConvertToDouble(string priceString)
        {
            if (priceString.Contains("."))
            {
                return Double.Parse(priceString, new CultureInfo("en-US"));
            }
            else
            {
                return Double.Parse(priceString);
            }
        } 
    }
}
