using Checkout.Domain;

namespace Checkout.Specs.StepDefinitions
{
    [Binding]
    public sealed class CheckoutStepDefinitions
    {
        private ICheckoutScanner<char>? _checkoutScanner;
        
        [Given("The following pricing rules:")]
        public void GivenItems(Table table)
        {
            var items = table.Rows.Select(ParseRow);
            _checkoutScanner = new SimpleCheckoutScanner(items);
        }

        [When("The following items are scanned out: (.*)")]
        public void WhenItemsScanned(string scannedItems)
        {
            foreach(char item in scannedItems)
            {
                _checkoutScanner!.Scan(item);
            }
        }

        [Then("The total price should be: (.*)")]
        public void AssertTotalPrice(decimal expectedPrice)
        {
            decimal actualPrice = _checkoutScanner!.GetTotal();
            Assert.Equal(expectedPrice, actualPrice);
        }

        private static PricingRule ParseRow(TableRow row)
        {
            var itemName = char.Parse(row["Item"]);
            var unitPrice = decimal.Parse(row["Unit Price"]);
            var specialPrice = ParseSpecialPrice(row["Special Price"]);

            return new PricingRule(itemName, unitPrice, specialPrice);
        }

        private static SpecialPrice? ParseSpecialPrice(string specialPriceStr)
        {
            if (string.IsNullOrWhiteSpace(specialPriceStr))
            {
                return null;
            }
            string[] tokens = specialPriceStr.Split(" for ");
            int quantity = int.Parse(tokens[0]);
            decimal price = decimal.Parse(tokens[1]);
            return new SpecialPrice(quantity, price);
        }
    }
}
