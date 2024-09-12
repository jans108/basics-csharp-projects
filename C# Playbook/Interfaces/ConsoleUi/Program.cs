using BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;
using Pluralsight.Interfaces.Demo.BuisnessObjects;

var repository = new ClientRepository("connection string");
GardenClient client = repository.GetClientFromId(1);
client.SaveCart();

ConsoleLogger logger = new ConsoleLogger();
client.Logger = logger;

client.LogMyself();

client.SaveCart();

