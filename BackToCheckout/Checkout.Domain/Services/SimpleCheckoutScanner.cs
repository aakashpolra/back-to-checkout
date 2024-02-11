using Checkout.Domain.Models;

namespace Checkout.Domain.Services;

/// <summary>
/// Implements <see cref="ICheckoutScanner{TItemId}"/> using char type of item identification.
/// This is a simple implementation for the given problem domain that uses simple pricing rules
/// with optional quantity based special pricing.
/// 
/// Please see:
/// http://codekata.com/kata/kata09-back-to-the-checkout/
/// </summary>
public class SimpleCheckoutScanner(IEnumerable<PricingRule> pricingRules) : ICheckoutScanner<char>
{
    private Dictionary<char, int> itemsInCarts = new();

    public void Scan(char itemName)
    {
        if (itemsInCarts.ContainsKey(itemName))
        {
            itemsInCarts[itemName]++;
        }
        else
        {
            itemsInCarts.Add(itemName, 1);
        }
    }

    public decimal GetTotal()
    {
        return CalculateTotal(pricingRules, itemsInCarts);
    }

    // Implementing calculation as a "pure" function
    private static decimal CalculateTotal(IEnumerable<PricingRule> pricingRules, Dictionary<char, int> itemInCarts)
    {
        decimal total = 0;
        Dictionary<char, PricingRule> pricingRulesDictionary = pricingRules.ToDictionary(rule => rule.Item);

        foreach (var itemName in itemInCarts.Keys)
        {
            // Check if special price exists
            SpecialPrice? specialPrice = pricingRulesDictionary[itemName].SpecialPrice;
            int itemsQty = itemInCarts[itemName];

            if (specialPrice is not null)
            {
                // Special price
                total += itemsQty / specialPrice.Quantity * specialPrice.Price;

                // Normal price
                total += itemsQty % specialPrice.Quantity * pricingRulesDictionary[itemName].NormalPrice;
            }
            else
            {
                total += itemsQty * pricingRulesDictionary[itemName].NormalPrice;
            }
        }
        return total;
    }
}
