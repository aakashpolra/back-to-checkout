namespace Checkout.Specs.StepDefinitions
{
    [Binding]
    public sealed class CheckoutStepDefinitions
    {
        [Given("The following pricing rules:")]
        public void GivenItems(Table table) { }

        [When("The following items are scanned out: (.*)")]
        public void WhenItemsScanned(string scannedItems) { }

        [Then("The total price should be: (.*)")]
        public void AssertTotalPrice(decimal totalPrice) { }
    }
}
