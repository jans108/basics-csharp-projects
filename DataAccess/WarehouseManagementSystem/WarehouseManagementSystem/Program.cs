using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem;

Customer filip = new()
{
    Id = Guid.NewGuid(),
    Name = "Filip Ekberg",
    Address = "Kungsbacka",
    PostalCode = "434 93",
    Country = "Sweden",
    PhoneNumber = "123456789"
};

ShippingProvider shippingProvider = new()
{
    Id = Guid.NewGuid(),
    Name = "Swedish Postal Service",
    FreightCost = 100m
};

Item item = new()
{ 
    Id = Guid.NewGuid(),
    Name = "Phone",
    Description = "Electronic",
    Price = 1,
    InStock = 1
};

Order order = new()
{
    Id = Guid.NewGuid(),
    Customer = filip,
    ShippingProvider = shippingProvider,
    LineItems = new LineItem[]
    {
        new()
        {
            Id = Guid.NewGuid(),
            Item = item,
            Quantity = 1
        }
    }
};

using var context = new WarehouseContext();
context.Database.Migrate();

context.Orders.Add(order);
context.SaveChanges();

















//using System.Data.SqlClient;
//using WarehouseManagementSystem;
//using Microsoft.EntityFrameworkCore;
//using Warehouse.Data.SQLite;
//using Order = Warehouse.Data.SQLite.Order;
//using LineItem = Warehouse.Data.SQLite.LineItem;
//using Customer = Warehouse.Data.SQLite.Customer;
//using Item = Warehouse.Data.SQLite.Item;
//using ShippingProvider = Warehouse.Data.SQLite.ShippingProvider;
//using Warehouse = Warehouse.Data.SQLite.Warehouse;

//using var context = new WarehouseSQLiteContext();

//var firstCustomer = context.Customers.First();
//Order newOrder = new()
//{
//    Id = Guid.NewGuid(),
//    LineItems = new LineItem[]
//    {
//        new()
//    {
//            Id = Guid.NewGuid(),
//            Item = context.Items.First(),
//            Quantity = 1
//    }
//    },
//    ShippingProvider = context.ShippingProviders.First(),
//    Customer = firstCustomer
//};

//context.Orders.Add(newOrder);
//context.SaveChanges();
//Console.WriteLine("Order added!");