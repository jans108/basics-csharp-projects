using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using StockAnalyzer.Processor;

[SimpleJob(RuntimeMoniker.Net80, baseline: true)]
[SimpleJob(RuntimeMoniker.Net472)]
[MemoryDiagnoser]
public class ProcessorBenchmarks
{
    [GlobalSetup]
    public void Setup()
    {
    }

    [Benchmark]
    public List<string> ProcessorSlow()
    {
        var result = new List<string>();

        var processorSlow = new Processor();

        processorSlow.Initialize();

        foreach (var stock in processorSlow.Stocks)
        {
            var min = processorSlow.Min(stock.Key);
            var max = processorSlow.Max(stock.Key);
            var average = processorSlow.Average(stock.Key);

            result.Add($"{min} {max} {average}");
        }

        return result;
    }

    [Benchmark]
    public List<string> ProcessorFast()
    {
        var result = new List<string>();

        var processorFast = new ProcessorFaster();

        processorFast.Initialize();

        foreach (var stock in processorFast.Stocks)
        {
            var min = stock.Value.Min;
            var max = stock.Value.Max;
            var average = stock.Value.Average;

            result.Add($"{min} {max} {average}");
        }

        return result;
    }
}