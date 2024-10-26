using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;

var order = new Order
{
    LineItems = new[]
    {
        new Item { Name = "PS1", Price = 50 },
        new Item { Name = "PS2", Price = 60 },
        new Item { Name = "PS3", Price = 70 },
        new Item { Name = "PS4", Price = 80 }

    }
};

var processor = new OrderProcessor()
{
    OnOrderInitialized = (order) => order.IsReadyForShipment
};

var processdOrders = new List<Guid>();

OrderProcessor.ProcessCompleted onCompleted = (order) =>
{
    processdOrders.Add(order.OrderNumber);
    Console.WriteLine($"Processed {order.OrderNumber}");
};

processor.Process(order, onCompleted);

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email for {order.OrderNumber}");
}
