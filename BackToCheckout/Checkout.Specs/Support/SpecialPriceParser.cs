using Checkout.Domain.Models;

namespace Checkout.Specs.Support;

public static class SpecialPriceParser
{
    const string SPECIAL_PRICE_SEPERATOR = " for ";

    /// <summary>
    /// Parses a valid special price input string.
    /// </summary>
    /// <param name="specialPriceStr">An empty or a valid special price string. E.g. "3 for 150"</param>
    /// <returns>A null or a SpecialPrice object containing Qantity and Price</returns>
    /// <exception cref="ArgumentException">Throws when the input string is not empty and is in invalid format</exception>
    public static SpecialPrice? Parse(string specialPriceStr)
    {
        if (string.IsNullOrWhiteSpace(specialPriceStr))
        {
            return null;
        }

        string[] tokens = specialPriceStr.Split(SPECIAL_PRICE_SEPERATOR);
        int quantity;
        decimal price;
        if (tokens.Length == 2 && int.TryParse(tokens[0], out quantity) &&
            decimal.TryParse(tokens[1], out price))
        {
            return new SpecialPrice(quantity, price);
        }
        throw new ArgumentException("Invalid format found for special price: ", specialPriceStr);
    }
}
