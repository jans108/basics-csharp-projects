using SweetCookiePieShop.InventoryManagment.Domain.General;
using SweetCookiePieShop.InventoryManagment.Domain.OrderManagment;
using SweetCookiePieShop.InventoryManagment.Domain.ProductManagment;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
