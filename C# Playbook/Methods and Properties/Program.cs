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

// Fluent coding in LINQ
var highValueSales = sales.EnumerateItems()
    .Where(s => s.Value > 100)
    .OrderBy(s => s.Customer.Name);