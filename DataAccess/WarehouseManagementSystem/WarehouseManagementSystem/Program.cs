
using Microsoft.Data.SqlClient;


var connectionString =
    "Data Source=(LocalDB)\\MSSQLLocalDB;" +
    "Initial Catalog=WarehouseManagement;" +
    "Integrated Security=True;";

using SqlConnection connection = new(connectionString);

using SqlCommand command = new(
    @"INSERT INTO [Customers]
    (Id, Name, Address, PostalCode, Country, PhoneNumber)
    VALUES(NEWID(), @Name, @Address, @PostalCode, @Country, @PhoneNumber)
    ",connection);

var nameParameter =
    new SqlParameter("Name", System.Data.SqlDbType.NVarChar);
nameParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(nameParameter);

var addressParameter =
    new SqlParameter("Address", System.Data.SqlDbType.NVarChar);
addressParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(addressParameter);

var postalCodeParameter =
    new SqlParameter("PostalCode", System.Data.SqlDbType.NVarChar);
postalCodeParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(postalCodeParameter);

var countryParameter =
    new SqlParameter("Country", System.Data.SqlDbType.NVarChar);
countryParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(countryParameter);

var phoneNumberParameter =
    new SqlParameter("PhoneNumber", System.Data.SqlDbType.NVarChar);
phoneNumberParameter.Value = Console.ReadLine().Trim();
command.Parameters.Add(phoneNumberParameter);

connection.Open();

var rowsAffected = command.ExecuteNonQuery();

Console.WriteLine($"Rows affected: { rowsAffected }");
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