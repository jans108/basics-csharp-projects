using SweetCookiePieShop.InventoryManagment.Domain.General;
using System.Text;


namespace SweetCookiePieShop.InventoryManagment.Domain.ProductManagment
{
    public class FreshProduct : Product
    {
        public DateTime ExpiryDateTime { get; set; }

        public string? StorageInstructions { get; set; }


        public FreshProduct(int id, string name, string? description, Price price, UnitType unitType, int maxAmountInStock) : base(id, name, description, price, unitType, maxAmountInStock)
        {
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public override string DisplayDetailsFull()
        {
            {
                StringBuilder sb = new();

                sb.Append($"{Id} {Name}  \n{Description}\n{Price}\n{AmountInStock}  item(s) in stock");


                if (IsBelowStockTreshold)
                {
                    sb.Append("\n!!STOCK LOW!!");
                }

                sb.AppendLine("Storage instructions: " + StorageInstructions);

                sb.AppendLine("Expiry date: " + ExpiryDateTime.ToShortDateString());

                return sb.ToString();
            }
        }
    }

    
}
