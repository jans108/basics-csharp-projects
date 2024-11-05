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

var avg = order.LineItems.Average(item => item.Price);

var result = order.LineItems.Where(item => item.Price > avg);

var subset = new
{
    order.OrderNumber,
    order.Total,
    AveragePrice = avg
};

IEnumerable<Order>? orders =
    JsonSerializer.Deserialize<Order[]>(
        File.ReadAllText("orders.json")
        );

processor.Process(orders);

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