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
            Product p1 = new(1, "Sugar", "Very sweet", new Price() { ItemPrice = 10, Currency = Currency.Euro }, UnitType.PerKg, 100);
            Product p2 = new(2, "Cake decorations", "Looks nice", new Price() { ItemPrice = 8, Currency = Currency.Euro }, UnitType.PerItem, 100);
            Product p3 = new(3, "Strawberry", "I love them", new Price() { ItemPrice = 3, Currency = Currency.Euro }, UnitType.PerBox, 10);
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
                            // SaveAllData();
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


        private static void ShowInventoryManagmmentMenu()
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
                        //ShowCreateNewProduct();
                        break;
                    case "3":
                        //ShowCloneExistingProduct();
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

        private static void ShowAllProductsOverview()
        {
            foreach (var product in inventory)
            {
                Console.WriteLine(product.DisplayDetailsShort);
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

            private static void ShowOrderManagmentMenu()
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

        }
    }
}
