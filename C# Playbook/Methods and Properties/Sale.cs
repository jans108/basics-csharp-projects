namespace Pluralsight.CShPlaybook.MethodsProps;

public class Sale
{
    public CookieCustomer Customer { get; }

    public decimal Value { get; }

    public Sale(CookieCustomer customer, decimal amount)
    {
        if (customer == null)
            throw new ArgumentNullException("A sale cannot have a null customer", nameof(customer));
        Customer = customer;
        Value = amount;
    }
}

