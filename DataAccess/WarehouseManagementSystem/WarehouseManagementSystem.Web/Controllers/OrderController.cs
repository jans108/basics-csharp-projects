using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Web.Models;
using WarehouseManagementSystem.Infrastructure;

namespace WarehouseManagementSystem.Web.Controllers;

public class OrderController : Controller
{
    private IRepository<Order> orderRepository;
    private IRepository<ShippingProvider> shippingProviderRepository;
    private IRepository<Item> itemRepository;

    public OrderController( IRepository<Order> orderRepository,
                            IRepository<ShippingProvider> shippingProviderRepository,
                            IRepository<Item> itemRepository)
    {
        this.orderRepository = orderRepository;
        this.shippingProviderRepository = shippingProviderRepository;
        this.itemRepository = itemRepository;
    }

    public IActionResult Index()
    {
        var orders =
            orderRepository.Find(
                order => order.CreatedAt > DateTime.UtcNow.AddDays(-1)
              );

        return View(orders);
    }

    public IActionResult Create()
    {
        var items = itemRepository.All();

        return View(items);
    }

    [HttpPost]
    public IActionResult Create(CreateOrderModel model)
    {
        #region Validate input
        if (!model.LineItems.Any()) return BadRequest("Please submit line items");

        if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");
        #endregion

        var customer = new Customer
        {
            Name = model.Customer.Name,
            Address = model.Customer.Address,
            PostalCode = model.Customer.PostalCode,
            Country = model.Customer.Country,
            PhoneNumber = model.Customer.PhoneNumber
        };

        var order = new Order
        {
            LineItems = model.LineItems
                .Select(line => new LineItem {
                    Id = Guid.NewGuid(),
                    ItemId = line.ItemId,
                    Quantity = line.Quantity
                })
                .ToList(),

            Customer = customer,
            ShippingProviderId = shippingProviderRepository.All().First().Id,
            CreatedAt = DateTimeOffset.UtcNow
        };

        orderRepository.Add(order);
        orderRepository.SaveChanges();

        return Ok("Order Created");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
