namespace Pluralsight.CShPlaybook.DrawingStuff;

public record struct MutablePoint(int X, int Y)
{
    public readonly int DistSqFrom(MutablePoint other)
        => (X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y);
    public readonly double DistFrom(MutablePoint other)
        => Math.Sqrt(DistSqFrom(other));
    public readonly override string ToString() => $"({X}, {Y})";
}
