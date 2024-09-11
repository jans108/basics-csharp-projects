using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

var repository = new ClientRepository("connection string");
GardenClient client = repository.GetClientFromId(1);
client.SaveCart();

DisplayClient(client);

void DisplayClient(GardenClient client)
{
	Console.WriteLine(client.Name);
	foreach (string item in client.ShoppingCart)
		Console.WriteLine($" In cart: {item}");
	Console.WriteLine();
}