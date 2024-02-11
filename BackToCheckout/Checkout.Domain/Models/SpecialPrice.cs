namespace Checkout.Domain.Models;

/// <summary>
/// Quantity based special price.
/// E.g. 3 for $130
/// </summary>
/// <param name="Quantity">Quantity or the multiples of which the special price is for</param>
/// <param name="Price">The special price for the given Quantity</param>
public record SpecialPrice(int Quantity, decimal Price);
