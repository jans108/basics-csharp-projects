using BenchmarkDotNet.Attributes;

namespace Benchmarks;

[SimpleJob]
[MemoryDiagnoser]
public class FlowControlBenchmarker
{
    [Benchmark]
    public decimal ProcessWithoutException()
    {
        decimal result = 0;

        for (int i = 0; i < 10000; i++)
        {
            var dimensions = GetDimensionsFor(i);

            if(dimensions is not null)
            {
                result += dimensions.Width;
            }
        }

        return result;
    }

    [Benchmark]
    public decimal ProcessWithException()
    {
        decimal result = 0;

        for (int i = 0; i < 10000; i++)
        {
            try
            {
                var dimensions = GetDimensionsFor(i);
                result += dimensions.Width;
            }
            catch
            {

            }
        }

        return result;
    }

    public Dimensions GetDimensionsFor(int index)
    {
        if (index % 10 == 0)
            return null!;
        return new(100, 100);
    }

    public record Dimensions(int Width, int Height);
}
