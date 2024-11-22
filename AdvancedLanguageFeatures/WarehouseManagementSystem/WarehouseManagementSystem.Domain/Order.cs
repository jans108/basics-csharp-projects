
using System.Text;
using System.Text.Json.Serialization;

namespace WarehouseManagementSystem.Domain
{
    public record Order(
        [property: JsonPropertyName("total")]
        decimal Total = 0m,

        [property: JsonIgnore]
        ShippingProvider ShippingProvider = default,
        IEnumerable<Item> LineItems = default,
        bool isReadyForShipment = true
        )
    {
        public Guid OrderNumber { get; init; } = Guid.NewGuid();


        //public Order()
        //{
        //    OrderNumber = Guid.NewGuid();
        //}

        public string GenerateReport(string email)
        {
            throw new NotImplementedException();
        }


        public void Deconstruct(out decimal total, out bool ready)
        {
            total = Total;
            ready = isReadyForShipment;
        }

        public void Deconstruct(out decimal total, out bool ready, out IEnumerable<Item> items)
        {
            total = Total;
            ready = isReadyForShipment;
            items = LineItems;
        }

        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append("A custom implementation");

            return true;
        }

    }


    public record PriorityOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems,
        bool isReadyForShipment = true
        )
        : Order(Total, ShippingProvider, LineItems, isReadyForShipment)
    { }

    public record ShippedOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems
        )
        : Order(Total, ShippingProvider, LineItems, false)
    {
        public DateTime ShippedDate { get; set; }
    }

    public record CancelledOrder(
        decimal Total,
        ShippingProvider ShippingProvider,
        IEnumerable<Item> LineItems
        )
        : Order(Total, ShippingProvider, LineItems, false)
    {
        public DateTime CanelledDate { get; set; }
    }

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
    }
}