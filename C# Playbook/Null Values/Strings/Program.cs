
Console.WriteLine("What do you want to buy?");
string? value = Console.ReadLine();

string valueToUse = string.IsNullOrWhiteSpace(value) ? "" : value;

if (valueToUse == "")
	Console.WriteLine("You don't want to buy anything");
else
	Console.WriteLine("You want to purchase " + value);
