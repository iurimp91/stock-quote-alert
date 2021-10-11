using System;
using Xunit;

namespace StockQuoteAlert.Tests
{
    public class InputHandlerTests
    {
        [Fact]
        public void ValidateAssetNameReturnsStringForValidInput()
        {
            var userInput = "petr4";

            var assetName = InputHandler.ValidateAssetName(userInput);

            Assert.Equal("petr4", assetName);
        }

        [Fact]
        public void ValidateAssetNameThrowsErrorForInvalidInput()
        {
            var userInput = "foobar";

            Assert.Throws<ArgumentException>(
                () => InputHandler.ValidateAssetName(userInput)
            );
        }

        [Fact]
        public void ValidatePriceReturnsDoubleForValidInput()
        {
            var userInput = "28.9";

            var price = InputHandler.ValidatePrice(userInput);

            Assert.IsType<double>(price);
            Assert.Equal(28.9, price);
        }

        [Fact]
        public void ValidatePriceThrowsErrorForInvalidInput()
        {
            var userInput = "0";

            Assert.Throws<ArgumentException>(
                () => InputHandler.ValidatePrice(userInput)
            );
        }

        [Fact]
        public void ValidatePriceThrowsErrorForSameValueOfBuyAndSellPrices()
        {
            var userInput = "28.9";
            var sellPrice = 28.9;
            
            Assert.Throws<ArgumentException>(
                () => InputHandler.ValidatePrice(userInput, sellPrice)
            );
        }

        [Fact]
        public void ValidatePriceReturnsADoubleRegardlessOfNumberFormat()
        {
            var userInputWithDot = InputHandler.ValidatePrice("28.9");
            var userInputWithComma = InputHandler.ValidatePrice("28,9");
            
            Assert.Equal(28.9, userInputWithDot);
            Assert.Equal(28.9, userInputWithComma);
        }
    }
}
