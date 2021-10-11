using System;
using System.Globalization;

namespace StockQuoteAlert
{
    public class InputHandler
    {
        public static string ValidateAssetName(string assetName)
        {   
            var assetData = ApiClient.GetAssetData(assetName);

            if (assetData.Contains("error"))
            {
               throw new ArgumentException("Nome do ativo inválido."); 
            }

            return assetName;
        }

        public static double ValidatePrice(string sellPriceInput)
        {
            var sellPrice = ConvertToDouble(sellPriceInput);

            if (sellPrice <= 0)
            {
                throw new ArgumentException("O valor deve ser maior que 0.");
            }

            return sellPrice;
        }

        public static double ValidatePrice(string buyPriceInput, double sellPrice)
        {
            var buyPrice = ConvertToDouble(buyPriceInput);

            while(buyPrice <= 0 || buyPrice == sellPrice)
            {
                throw new ArgumentException("O valor deve ser maior que 0 e não pode ser igual ao valor de venda.");
            }

            return buyPrice;
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
