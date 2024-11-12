namespace WarehouseManagementSystem.Domain
{
    public record Customer(string Firstname, string Lastname);
    
    public record PriorityCustomer(string Firstname, string Lastname) : Customer(Firstname, Lastname);
}
