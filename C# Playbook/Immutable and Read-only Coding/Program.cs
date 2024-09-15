using Pluralsight.CShPlaybook.DrawingStuff;

MutablePoint point = new MutablePoint(4, 4);
Console.WriteLine($"Norm is {Norm(point)}");

static double Norm(in MutablePoint pt) => pt.DistSqFrom(new MutablePoint(0, 0));