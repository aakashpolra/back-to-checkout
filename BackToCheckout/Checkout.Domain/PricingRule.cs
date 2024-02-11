namespace Checkout.Domain;

/// <summary>
/// A pricing rule with a normal price and an optional quantity-based special price.
/// </summary>
/// <param name="Item">Name of the item</param>
/// <param name="NormalPrice">Price per item</param>
/// <param name="SpecialPrice">Optional special price for a minimum number of items</param>
public record PricingRule(char Item, decimal NormalPrice, SpecialPrice? SpecialPrice);
