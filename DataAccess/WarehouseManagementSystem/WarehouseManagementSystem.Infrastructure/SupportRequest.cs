using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.Infrastructure;

public class SupportRequest : ITableEntity
{
    public string PartitionKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string RowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTimeOffset? Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ETag ETag { get; set; }

    public string Email { get; set; }
    public string Message { get; set; }
}
