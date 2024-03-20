using System.Data.SqlClient;
using WarehouseManagementSystem;
using Microsoft.EntityFrameworkCore;

using var context = new WarehouseContext();

var firstCustomer = context.Customers.First();
firstCustomer.Orders.Add(new()
{
    Id = Guid.NewGuid(),
    LineItems = new LineItem[]
    {
        new()
    {
            Id = Guid.NewGuid(),
            Item = context.Items.First(),
            Quantity = 1
    }
    },
    ShippingProvider = context.ShippingProviders.First()
});

context.Customers.Update(firstCustomer);
context.SaveChanges();
Console.WriteLine("Customer updated!");