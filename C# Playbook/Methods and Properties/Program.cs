using Pluralsight.CShPlaybook.MethodsProps;

CookieCustomer jimmy = new(1, "Jimmy");
CookieCustomer rock = new(2, "Rock");
CookieCustomer jack = new(3, "Jack");

SalesList sales = new();
sales.AddSale(new(jimmy, 200))
    .AddSale(new(rock, 150))
    .AddSale(new(jack, 400))
    .AddSale(new(jimmy, 600))
    .AddSale(new(rock, 50))
    .AddSale(new(jack, 1000));

(string name, decimal totalValue, int NSales) = sales.GetHighestValueCustomer();

Console.WriteLine("Highest spender: ");
Console.WriteLine($"{name} Spent {totalValue} in {NSales} purchases");

var highest = sales.GetHighestValueCustomer();

Console.WriteLine("\r\nHighest spender: ");
Console.WriteLine($"{highest.CustomerName} Spent {highest.TotalSpent} in {highest.NSales} pruchases");

bool eligible = BusinessRules.EligibleForVoucher(NSales, in totalValue);
Console.WriteLine($"\nIs {name} eligible for voucher? {eligible}");

// Fluent coding in LINQ
var highValueSales = sales.EnumerateItems()
    .Where(s => s.Value > 100)
    .OrderBy(s => s.Customer.Name);