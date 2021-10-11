using System;
using Xunit;

namespace StockQuoteAlert.Tests
{
    public class InputHandlerTests
    {
        [Fact]
        public void AssetName()
        {
            var userInput = "petr4";

            var assetName = InputHandler.GetAndValidateAssetName(userInput);
        }
    }
}
