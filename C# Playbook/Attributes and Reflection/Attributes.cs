namespace Pluralsight.CShPlaybook.AttribsReflection;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class ActualProductAttribute : Attribute
{
    public bool CanUseInTemplate { get; set; }
}
