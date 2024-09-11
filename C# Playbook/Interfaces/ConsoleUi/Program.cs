using BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

var repository = new ClientRepository("connection string");
GardenClient client = repository.GetClientFromId(1);
client.SaveCart();


Console.WriteLine($"Client.Name = {client.Name}");
Console.WriteLine();
ILoggable clientAsLoggable = client as ILoggable;
Console.WriteLine($"ILoggable.Name = {clientAsLoggable.Name}");
Console.WriteLine($"ILoggable.CurrentState = {clientAsLoggable.CurrentState}");
Console.WriteLine();


