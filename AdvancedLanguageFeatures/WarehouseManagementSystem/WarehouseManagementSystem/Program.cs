using System.Text.Json;
using System.Text.Json.Nodes;
using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;
using WarehouseManagementSystem.Domain.Extensions;

var items = new List<Item>()
{
    new Item() {Name = "Pen", Price = 4},
    new Item() {Name = "Book", Price = 15}
};

Order order = new Order(101, null, items);

CancelledOrder cancelledOrder = new(101, new(), items);

var processor = new OrderProcessor();

processor.OrderProcessCompleted += Processor_OrderProcessCompleted;

void Processor_OrderProcessCompleted(object? sender, OrderProcessCompletedEventArgs args)
{
    if (args.Order is  null)
    {
        return;
    }

    Guid orderNumber = args.Order.OrderNumber;

    string orderNumberAsString = orderNumber.ToString();

    ShippingProvider? provider =
        args.Order.ShippingProvider;

    // provider ??= new();

    if (ShippingProviderValidator.ValidateShippingProvider(provider))
    {
        var name = provider.Name;
    }

}

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