namespace Checkout.Domain;

/// <summary>
/// Implements <see cref="ICheckoutScanner{TItemId}"/> using char type of item identification.
/// This is a simple implementation for the given problem domain that uses simple pricing rules
/// with optional quantity based special pricing.
/// 
/// Please see:
/// http://codekata.com/kata/kata09-back-to-the-checkout/
/// </summary>
public class SimpleCheckoutScanner : ICheckoutScanner<char>
{
    public void Scan(char itemIdentifier)
    {
        throw new NotImplementedException();
    }

    public decimal GetTotal()
    {
        throw new NotImplementedException();
    }
}
