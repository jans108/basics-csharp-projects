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
    OnOrderInitialized = SendMessageToWarehouse
};

OrderProcessor.ProcessCompleted chain = (OrderProcessor.ProcessCompleted)One + Two + Three;


processor.Process(order, chain);

chain -= Two;

processor.Process(order, chain);

bool SendMessageToWarehouse(Order order)
{
    Console.WriteLine($"Please pack the order {order.OrderNumber}");

    return true;
}

void SendConfirmationEmail(Order order)
{
    Console.WriteLine($"Order Confirmation Email for {order.OrderNumber}");
}

void One(Order order) => Console.WriteLine("One");
void Two(Order order) => Console.WriteLine("Two");
void Three(Order order) => Console.WriteLine("Three");