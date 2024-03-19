using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem;

using var context = new WarehouseContext();

var customer = context.Customers
    .Include(customer => customer.Orders)
    .FirstOrDefault(customer => customer.Name == "Filip Ekberg");

foreach(var order in context.Orders
    .Where(order => order.Customer.Name.Contains("Ekberg"))
    .Include(order => order.Customer)
    .Include(order => order.ShippingProvider)
    .Include(order => order.LineItems)
    .ThenInclude(lineItem => lineItem.Item))
    
{
    Console.WriteLine($"Order Id: {order.Id}");
    Console.WriteLine($"Customer: {order.Customer.Name}");
    Console.WriteLine($"Shipping provider: {order.ShippingProvider}");
    foreach(var lineItem in order.LineItems)
    {
        Console.WriteLine($"\t{lineItem.Item.Name}");
        Console.WriteLine($"\t{lineItem.Item.Price}");
    }
}

Console.ReadLine();