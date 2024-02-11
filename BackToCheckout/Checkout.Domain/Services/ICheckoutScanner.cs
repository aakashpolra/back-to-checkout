namespace Checkout.Domain.Services;

/// <summary>
/// Defines a checkout scanner that scans items and calculates the total amount.
/// </summary>
/// <typeparam name="TItemId">Type of the item identifier (e.g. char)</typeparam>
public interface ICheckoutScanner<TItemId>
{
    /// <summary>
    /// Scans an item.
    /// </summary>
    /// <param name="itemIdentifier">Item identifier (e.g. 'A')</param>
    public void Scan(TItemId itemIdentifier);

    /// <summary>
    /// Returns the current total of all scanned items.
    /// </summary>
    /// <returns>Total amount</returns>
    public decimal GetTotal();
}
