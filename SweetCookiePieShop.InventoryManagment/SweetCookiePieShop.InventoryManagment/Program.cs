
using SweetCookiePieShop.InventoryManagment;

PrintWelcome();

Utilities.InitializeStock();

Utilities.ShowMainMenu();

Console.WriteLine("Application shutting down...");

Console.ReadLine();


#region Layout

static void PrintWelcome()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(" _____                   _   _____             _    _     ______ _      _____ _                 ");
    Console.WriteLine("/  ___|                 | | /  __ \\           | |  (_)    | ___ (_)    /  ___| |                ");
    Console.WriteLine("\\ `--.__      _____  ___| |_| /  \\/ ___   ___ | | ___  ___| |_/ /_  ___\\ `--.| |__   ___  _ __  ");
    Console.WriteLine(" `--. \\ \\ /\\ / / _ \\/ _ \\ __| |    / _ \\ / _ \\| |/ / |/ _ \\  __/| |/ _ \\`--. \\ '_ \\ / _ \\| '_ \\ ");
    Console.WriteLine("/\\__/ /\\ V  V /  __/  __/ |_| \\__/\\ (_) | (_) |   <| |  __/ |   | |  __/\\__/ / | | | (_) | |_) |");
    Console.WriteLine("\\____/  \\_/\\_/ \\___|\\___|\\__|\\____/\\___/ \\___/|_|\\_\\_|\\___\\_|   |_|\\___\\____/|_| |_|\\___/| .__/ ");
    Console.WriteLine("                                                                                         | |    ");
    Console.WriteLine("                                                                                         |_|    ");
 
    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    Console.ReadLine();

    Console.Clear();
}

#endregion