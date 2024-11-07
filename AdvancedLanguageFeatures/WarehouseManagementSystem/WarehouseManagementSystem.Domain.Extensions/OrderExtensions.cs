using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Domain.Extensions
{
    public static class OrderExtensions
    {
        public static string GenerateReport
            (this Order order)
        {
            return $"ORDER REPORT ({order.OrderNumber})" +
                $"{Environment.NewLine}" +
                $"Items: {order.LineItems.Count()}" +
                $"{Environment.NewLine}" +
                $"Total: {order.Total}" +
                $"{Environment.NewLine}";
        }

        public static string GenerateReport
    (this Order order, string recipient)
        {
            return $"ORDER REPORT ({order.OrderNumber})" +
                $"{Environment.NewLine}" +
                $"Items: {order.LineItems.Count()}" +
                $"{Environment.NewLine}" +
                $"Total: {order.Total}" +
                $"{Environment.NewLine}" +
                $"Send to: {recipient}";
        }

        public static string GenerateReport
            (this (Guid, int, decimal) order)
        {
            return $"ORDER REPORT ({order.Item1})" +
                 $"{Environment.NewLine}" +
                 $"Items: {order.Item2}" +
                 $"{Environment.NewLine}" +
                 $"Total: {order.Item3}" +
                 $"{Environment.NewLine}";
        }
    }
}
