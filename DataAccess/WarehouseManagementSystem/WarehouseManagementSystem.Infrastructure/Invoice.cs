using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Infrastructure
{
    public class Invoice
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        public Guid OrderId { get; set; }
        public decimal AmountDue { get; set; }
        public DateOnly DueDate { get; set; }
    }
}
