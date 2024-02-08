using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment.Domain.OrderManagment
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime OrderFulfilmentDate { get; private set; }

        public List<OrderItem> OrderItems { get; }

        public bool Fulfielld { get; set; } = false;

        public Order() 
        {
            Id = new Random().Next(99999);

            int numberOfSeconds = new Random().Next(10);
            OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

            OrderItems = new List<OrderItem>();
        }

        public string ShowOrderDetails()
        {
            StringBuilder orderDetails = new StringBuilder();

            orderDetails.AppendLine($"Order ID: {Id}");
            orderDetails.AppendLine($"Order fulfilment date: { OrderFulfilmentDate.ToShortTimeString()}");

            if (OrderItems !=  null)
            {
                foreach (OrderItem item in OrderItems )
                {
                    orderDetails.AppendLine($"{item.ProductId}. {item.ProductName}: {item.AmountOrdered}");
                }
            }

            return orderDetails.ToString();
        }
    }
}
