namespace Pluralsight.CShPlaybook.AttribsReflection;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class ActualProductAttribute : Attribute
{
    public bool CanUseInTemplate { get; set; }
}

[AttributeUsage(AttributeTargets.Field)]
public sealed class FriendlyTextAttribute : Attribute
{
    public string FriendlyText { get; }

    public FriendlyTextAttribute(string friendlyText)
    {
        FriendlyText = friendlyText;
    }
}
