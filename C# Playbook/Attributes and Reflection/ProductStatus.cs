namespace Pluralsight.CShPlaybook.AttribsReflection;

public enum ProductStatus
{
	[FriendlyText("In stock")]
	InStock,

	[FriendlyText("Out of stock")]
	OutOfStock,

	[FriendlyText("No longer available")]
	Discontinued,

	[FriendlyText("Coming soon!")]
	NotYetLaunched
}

