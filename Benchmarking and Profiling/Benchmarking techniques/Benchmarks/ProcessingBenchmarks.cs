using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using StockAnalyzer.Processor;

namespace Benchmarks;

[SimpleJob]
[MemoryDiagnoser]
public class ProcessingBenchmarks
{
    [GlobalSetup]
    public void Setup()
    {
        // we can do some methods without benchmarking. Depends on our goal.
    }

    [Benchmark]
    public List<string> Processor()
    {
        var result = new List<string>();

        var processor = new Processor();

        processor.Initialize();

        foreach (var stock in processor.Stocks)
        {
            var min = processor.Min(stock.Key);
            var max = processor.Max(stock.Key);
            var avarage = processor.Average(stock.Key);

            result.Add($"{min} {max} {avarage}");
        }

        return result;
    }

    [Benchmark]
    public List<string> ProcessorFaster()
    {
        return [];
    }
}
