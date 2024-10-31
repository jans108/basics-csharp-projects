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

Func<Order, bool> isReadyForShipment = (order) =>
{
    return order.IsReadyForShipment;
};

var processor = new OrderProcessor()
{
    OnOrderInitialized = isReadyForShipment
};

var processdOrders = new List<Guid>();

Action<Order> onCompleted = (order) =>
{
    processdOrders.Add(order.OrderNumber);
    Console.WriteLine($"Processed {order.OrderNumber}");
};

onCompleted += (order) => { };

processor.OrderCreated += (sender, args) =>
{
    
};

processor.OrderCreated += Log;

processor.Process(order, onCompleted);


void Log(object sender, EventArgs args)
{
    Console.WriteLine("Order created");
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
