using BusinessObjects;
using System.Text;

namespace Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

public class GardenClient : ILoggable
{
    public int Id { get; private init; }

    public string Name { get; private init; }

    public List<string> ShoppingCart { get; private init; } = new();

    string ILoggable.Name => $"Client Id = {Id}";

    string ILoggable.CurrentState
    {
        get
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id={Id}, Name={Name}, {ShoppingCart.Count} purchases");
            foreach (string purchase in ShoppingCart)
                sb.AppendLine("     purchased: " + purchase);
            return sb.ToString();
        }
    }

    private IClientRepository _repository;

    public GardenClient(int id, string name, IClientRepository repository)
    {
        Id = id;
        Name = name;
        _repository = repository;
    }

    public void AddToCart(string itemName)
    {
        ShoppingCart.Add(itemName);
    }

    public void SaveCart()
    {
        _repository.PersistCart(this);
    }
}

