
using Microsoft.Data.SqlClient;


var connectionString =
    "Data Source=(LocalDB)\\MSSQLLocalDB;" +
    "Initial Catalog=WarehouseManagement;" +
    "Integrated Security=True;"; 

using SqlConnection connection = new(connectionString);

using SqlCommand command = new(
    "SELECT * FROM [Orders]" +
    "INNER JOIN [Customers] ON" +
    "[Customers].Id = [Orders].CustomerId", connection);

connection.Open(); 

using var reader = command.ExecuteReader();

if(reader.HasRows == false)
{
    return;
}

while(reader.Read())
{
    var orderId = reader["Id"];
    var customer = reader["Name"];

    Console.WriteLine(orderId);
    Console.WriteLine(customer);
}



Console.ReadLine();



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