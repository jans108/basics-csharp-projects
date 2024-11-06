using System.Text.Json;
using System.Text.Json.Nodes;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var order = new Order
{
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS4", Price = 70 },
        new Item { Name = "PS5", Price = 80 }
    }
};

var processor = new OrderProcessor();


IEnumerable<Order>? orders =
    JsonSerializer.Deserialize<Order[]>(
        File.ReadAllText("orders.json")
        );

var result = processor.Process(orders);

var type = result.GetType();
var properties = type.GetProperties();

var group = (order.OrderNumber,
    order.LineItems,
    Sum: order.LineItems.Sum(item => item.Price));

var groupAsAnonymousType = new
{
    order.OrderNumber,
    order.LineItems,
    Sum = order.LineItems.Sum(item => item.Price)
};

var json = JsonSerializer.Serialize(group, options: new() { IncludeFields = true});
Console.WriteLine(json);

void Log(object sender, EventArgs args)
{
    Console.WriteLine("Log method call");
}

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email for {order.OrderNumber}");
}

Console.ReadLine();