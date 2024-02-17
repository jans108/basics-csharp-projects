﻿using SweetCookiePieShop.InventoryManagment.Domain.Contracts;
using SweetCookiePieShop.InventoryManagment.Domain.General;
using SweetCookiePieShop.InventoryManagment.Domain.OrderManagment;
using SweetCookiePieShop.InventoryManagment.Domain.ProductManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SweetCookiePieShop.InventoryManagment
{
    internal class Utilities
    {
        private static List<Product> inventory = new();
        private static List<Order> orders = new();

        internal static void InitializeStock()
        {
            RegularProduct rp = new RegularProduct(5, "Pie candles", "Lorem ipsum", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerItem, 100);

            double value = rp.ConvertProductPrice(Currency.Dollar);


            BoxedProduct bp = new(4, "Eggs", "From hen", new Price() { ItemPrice = 10, Currency = Currency.Euro }, 100, 6);

            bp.IncreaseStock(100);
            bp.UseProduct(10);

            Product p1 = new RegularProduct(1, "Sugar", "Very sweet", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);
            Product p2 = new RegularProduct(2, "Cake decorations", "Looks nice", new Price() { ItemPrice = 8, Currency = Currency.Euro }, UnitType.PerItem, 100);
            Product p3 = new RegularProduct(3, "Strawberry", "I love them", new Price() { ItemPrice = 3, Currency = Currency.Euro }, UnitType.PerBox, 10);
            inventory.Add(p1);
            inventory.Add(p2);
            inventory.Add(p3);
        }
        internal static void ShowMainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Inventory managment");
            Console.WriteLine("2: Order managment");
            Console.WriteLine("3: Settings");
            Console.WriteLine("4: Save all data");
            Console.WriteLine("0: Close application");

            Console.Write("Your selection: ");

            string userSelectionString;
            int userSelection;


            do
            {
                Console.WriteLine("Please enter your selection:");
                userSelectionString = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(userSelectionString))
                {
                    Console.WriteLine("Ivalid input. Please enter a valid selection.");
                }
                else if (int.TryParse(userSelectionString, out userSelection))
                {
                    switch (userSelection)
                    {
                        case 1:
                            ShowInventoryManagementMenu();
                            break;
                        case 2:
                            ShowOrderManagementMenu();
                            break;
                        case 3:
                            ShowSettingsMenu();
                            break;
                        case 4:
                            SaveAllData();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric selection.");
                }
            } while (string.IsNullOrEmpty(userSelectionString) || !int.TryParse(userSelectionString, out userSelection));
        }

        private static void SaveAllData()
        {
            ProductRepository productRepository = new();

            List<ISaveable> saveables = new List<ISaveable>();

            foreach (var item in inventory)
            {
                if (item is ISaveable)
                {
                    saveables.Add(item as ISaveable);
                }
            }

            productRepository.SaveToFile(saveables);

            Console.ReadLine();
            ShowMainMenu();
        }


        private static void ShowInventoryManagementMenu()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("***********************");
                Console.WriteLine("* Inventory managment *");
                Console.WriteLine("***********************");

                ShowAllProductsOverview();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1. View details of product");
                Console.WriteLine("2: Add new product");
                Console.WriteLine("3: Clone product");
                Console.WriteLine("4: View products with low stock");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowDetailsAndUseProduct();
                        break;
                    case "2":
                        ShowCreateNewProduct();
                        break;
                    case "3":
                        ShowCloneExistingProduct();
                        break;
                    case "4":
                        ShowProductsLowOnStock();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }

            } while (userSelection != "0");
            ShowMainMenu();

        }

        private static void ShowCloneExistingProduct()
        {
            string? userSelection = string.Empty;
            string? newId = string.Empty;

            Console.Write("Enter the ID of product to clone: ");
            string? selectedProductId = Console.ReadLine();

            if (selectedProductId != null)
            {
                Product? selectedProduct = inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();

                if (selectedProduct != null)
                {
                    Console.Write("Enter the new ID of the cloned product: ");

                    newId = Console.ReadLine();

                    Product? p = selectedProduct.Clone() as Product;
                    
                    if (p != null)
                    {
                        p.Id = int.Parse(newId);
                        inventory.Add(p);
                    }
                }
            }
        }

        private static void ShowCreateNewProduct()
        {
            UnitType unitType = UnitType.PerItem; //default

            Console.WriteLine("What type of product do you want to create?");
            Console.WriteLine("1. Regular product\n2. Bulk product\n3. Fresh product\n4.Boxed product");
            Console.Write("Your selection: ");

            var productType = Console.ReadLine();
            if (productType != "1" && productType != "2" && productType != "3" && productType != "4")
            {
                Console.WriteLine("Invalid selection!");
                return;
            }

            Product? newProduct = null;

            Console.Write("Enter the name of the product: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the price of the product: ");
            double price = double.Parse(Console.ReadLine() ?? "0.0");

            ShowAllCurrencies();
            Currency currency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine() ?? "1");

            Console.Write("Enter the description of the product: ");
            string description = Console.ReadLine() ?? string.Empty;

            if (productType == "1")
            {
                ShowAllUnitTypes();
                Console.Write("Select the unit type: ");
                unitType = (UnitType)Enum.Parse(typeof(UnitType), Console.ReadLine() ?? "1");
            }

            Console.Write("Enter the maximum number of items in stock for this product: ");
            int maxInStock = int.Parse(Console.ReadLine() ?? "0");

            int newId = inventory.Max(p => p.Id) + 1;

            switch (productType)
            {
                case "1":
                    newProduct = new RegularProduct(newId, name, description, new Price() { ItemPrice = price, Currency = currency }, unitType, maxInStock);
                    break;
                case "2":
                    newProduct = new BulkProduct(newId++, name, description, new Price() { ItemPrice = price, Currency = currency }, maxInStock);
                    break;
                case "3":
                    newProduct = new FreshProduct(newId++, name, description, new Price() { ItemPrice = price, Currency = currency }, unitType, maxInStock);
                    break;
                case "4":
                    Console.Write("Enter the number of items per box: ");
                    int numberInBox = int.Parse(Console.ReadLine() ?? "0");

                    newProduct = new BoxedProduct(newId++, name, description, new Price() { ItemPrice = price, Currency = currency }, maxInStock, numberInBox);
                    break;
            }

            if (newProduct != null)
                inventory.Add(newProduct);
        }

        private static void ShowAllUnitTypes()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof(UnitType)))
            {
                Console.WriteLine($"{i}. {name}");
                i++;
            }
        }

        private static void ShowAllCurrencies()
        {
            int i = 1;
            foreach (string name in Enum.GetNames(typeof (Currency)))
            {
                Console.WriteLine($"{i}. {name}");
                i++;
            }
        }

        private static void ShowAllProductsOverview()
        {
            foreach (var product in inventory)
            {
                Console.WriteLine(product.DisplayDetailsShort());
                Console.WriteLine();
            }
        }

        private static void ShowDetailsAndUseProduct()
        {
            string? userSelection = string.Empty;

            Console.Write("Enter the ID of product: ");
            string? selectedProductId = Console.ReadLine();

            if (selectedProductId != null)
            {
                Product? selectedProduct = inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();

                if (selectedProduct != null)
                {
                    Console.WriteLine(selectedProduct.DisplayDetailsFull());

                    Console.WriteLine("\n What do you want to do?");
                    Console.WriteLine("1: Use product");
                    Console.WriteLine("2: Back to inventory overview");

                    Console.Write("Your selection: ");
                    userSelection = Console.ReadLine();

                    if (userSelection == "1")
                    {
                        Console.WriteLine("How many products do you want to use?");
                        int amount = int.Parse(Console.ReadLine() ?? "0");

                        selectedProduct.UseProduct(amount);

                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Non-existing product selected. Please try again.");
            }
        }

            private static void ShowProductsLowOnStock()
            {
                List<Product> lowOnStockProducts = inventory.Where(p => p.IsBelowStockTreshold).ToList();

                if(lowOnStockProducts.Count > 0)
                {
                    Console.WriteLine("The following items are low on stock, order more soon!");

                    foreach(var product in lowOnStockProducts)
                    {
                        Console.WriteLine(product.DisplayDetailsShort());
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No items are currently low on stock!");
                }
                Console.ReadLine() ;
            }

            private static void ShowOrderManagementMenu()
            {
                string? userSelection = string.Empty;

                do
                {
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("*******************");
                    Console.WriteLine("* Select an action*");
                    Console.WriteLine("*******************");

                    Console.WriteLine("1: Open order overview");
                    Console.WriteLine("2: Add new order");
                    Console.WriteLine("0: Back to main menu");

                    Console.Write("Your selection: ");

                    userSelection = Console.ReadLine();

                    switch (userSelection)
                    {
                        case "1":
                            ShowOpenOrderOverview();
                            break;
                        case "2":
                            ShowAddNewOrder();
                            break;
                        default:
                            Console.WriteLine("Ivalid selection. Please try again.");
                            break;
                    }

                }
                while (userSelection != "0");
                ShowMainMenu();
            }
        
        private static void ShowOpenOrderOverview() 
        {
            ShowFulfilledOrders();

            if (orders.Count > 0)
            {
                Console.WriteLine("Open orders:");

                foreach (var order in orders)
                {
                    Console.WriteLine(order.ShowOrderDetails());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There are no open orders");
            }

            Console.ReadLine();
        }

        private static void ShowFulfilledOrders()
        {
            Console.WriteLine("Checking fulfilled orders.");
            foreach (var order in orders)
            {
                if (!order.Fulfielld && order.OrderFulfilmentDate < DateTime.Now)
                {
                    foreach (var orderItem in order.OrderItems)
                    {
                        Product? selectedProduct = inventory.Where(p => p.Id == orderItem.ProductId).FirstOrDefault();
                        if (selectedProduct != null)
                            selectedProduct.IncreaseStock(orderItem.AmountOrdered);
                    }
                    order.Fulfielld = true;
                }
            }

            orders.RemoveAll(o => o.Fulfielld);

            Console.WriteLine("Fulfilled orders checked");
        }

        private static void ShowAddNewOrder()
        {
            Order newOrder = new Order();
            string? selectedProductId = string.Empty;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Creating new order");
            Console.ResetColor();

            do
            {
                ShowAllProductsOverview();

                Console.WriteLine("Which product do you want to order?  (enter 0 to stop adding new products to the order)");

                Console.Write("Enter the ID of product: ");
                selectedProductId = Console.ReadLine();

                if ( selectedProductId != "0")
                {
                    Product? selectedProduct = inventory.Where(p => p.Id == int.Parse(selectedProductId)).FirstOrDefault();

                    if ( selectedProduct != null )
                    {
                        Console.Write("How many do you want to order?: ");
                        int amountOrdered = int.Parse(Console.ReadLine() ?? "0");

                        OrderItem orderItem = new OrderItem
                        {
                            ProductId = selectedProduct.Id,
                            ProductName = selectedProduct.Name,
                            AmountOrdered = amountOrdered,
                        };

                        newOrder.OrderItems.Add(orderItem);
                    }
                }
            }
            while (selectedProductId != "0");

            Console.WriteLine("Creating order...");

            orders.Add(newOrder);

            Console.WriteLine("Order now created.");
            Console.ReadLine();
        }

        private static void ShowSettingsMenu()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************");
                Console.WriteLine("* Settings *");
                Console.WriteLine("************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: Change stock threshold");
                Console.WriteLine("0: Back to main menu");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowChangeStockThreshold();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowMainMenu();
        }

        private static void ShowChangeStockThreshold()
        {
            Console.WriteLine($"Enter the new stock thresold (current value: {Product.StockThreshold}). This applies to all products!");
            Console.Write("New value: ");
            int newValue = int.Parse( Console.ReadLine() ?? "0");
            Product.StockThreshold = newValue;
            Console.WriteLine($"New stock threshold set to {Product.StockThreshold}");

            foreach (var product in inventory)
            {
                product.UpdateLowStock();
            }

            Console.ReadLine();
        }
    }
}
