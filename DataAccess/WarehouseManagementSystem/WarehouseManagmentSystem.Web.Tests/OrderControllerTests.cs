using Moq;
using Warehouse.Data.SQLite;
using WarehouseManagementSystem.Web.Controllers;
using WarehouseManagementSystem.Web.Models;
using WarehouseManagmentSystem.Infrastructure;

namespace WarehouseManagmentSystem.Web.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {
            //Arrange
            var orderRepository = new Mock<IRepository<Order>>();
            var itemRepository = new Mock<IRepository<Item>>();
            var shippingProviderRepository = new Mock<IRepository<ShippingProvider>>();

            shippingProviderRepository.Setup(
                repository => repository.All())
                .Returns(new[] { new ShippingProvider() });

            var orderController = new OrderController(
                orderRepository.Object,
                shippingProviderRepository.Object,
                itemRepository.Object);

            var createOrderModel = new CreateOrderModel
            {
                Customer = new()
                {
                    Name = "Filip Ekberg",
                    Address = "Kungsbacka",
                    PostalCode = "12345",
                    Country = "Sweden",
                    PhoneNumber = "123456789",
                },
                LineItems = new[]
                {
                    ItemId = Guid.NewGuid(),
                    Quantity = 100
                }
            };

            //Act
            orderController.Create(createOrderModel);

            //Assert
            orderRepository.Verify(
                repository => repository.Add(It.IsAny<Order>())
                Times.AtMostOnce()
                );
        }
    }
}