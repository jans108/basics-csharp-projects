using System.ComponentModel;
namespace Pluralsight.CShPlaybook.EventsDemo;

public class PriceAlerter
{
	public static void AlertPriceChanged(object? sender, EventArgs e)
	{
		BookmarkProduct product = (BookmarkProduct)sender!;
		if (product.Price < 0)
		{
			Console.WriteLine($"{product.Name} is no longer for sale");
			product.PriceChanged -= AlertPriceChanged;
		}
		else
		{
			Console.WriteLine($"{product.Name} changed to {product.Price}");
			product.PriceChanged += AlertPriceChanged;
		}
	}
}