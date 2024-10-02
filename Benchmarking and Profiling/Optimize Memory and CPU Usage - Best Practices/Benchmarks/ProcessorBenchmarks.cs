using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using StockAnalyzer.Processor;
using System.Runtime.InteropServices.Marshalling;

namespace Benchmarks;

[SimpleJob]
[MemoryDiagnoser]
[AsciiDocExporter]
[PlainExporter]
[RPlotExporter]
[XmlExporter]
public class ProcessorBenchmarks
{
private readonly Consumer consumer = new Consumer();

[Benchmark]
public void Process()
{
    Compute().Consume(consumer);
}

public IEnumerable<string> Compute()
{
    yield return "OK";
}

    Processor processor;

    [GlobalSetup]
    public void Setup()
    {
        processor = new();
        processor.Initialize();
    }

    [Benchmark]
    public List<string> Processor()
    {
        var result = new List<string>();

        foreach (var stock in processor.Stocks)
        {
            var min = processor.Min(stock.Key);
            var max = processor.Max(stock.Key);
            var average = processor.Average(stock.Key);

            result.Add($"{min} {max} {average}");
        }

        return result;
    }

    [Benchmark]
    public List<string> ProcessorFaster()
    {
        var result = new List<string>();

        foreach(var stock in processor.Stocks)
        {
            result.Add($"{stock.Value.Min} {stock.Value.Max} {stock.Value.Average}");
        }
        return result;
    }

    [Benchmark]
    public async Task<List<string>> ProcessorFasterAsync()
    {
        var result = new List<string>();

        var processor = new ProcessorFaster();

        await processor.InitializeAsync();

        foreach (var stock in processor.Stocks)
        {
            result.Add($"{stock.Value.Min} {stock.Value.Max} {stock.Value.Average}");
        }
        return result;
    }

    [Benchmark]
    public async Task<List<string>> ProcessorFasterAsync_V2()
    {
        var result = new List<string>();

        var processor = new ProcessorFaster();

        await processor.InitializeAsync_V2();

        foreach (var stock in processor.Stocks)
        {
            result.Add($"{stock.Value.Min} {stock.Value.Max} {stock.Value.Average}");
        }
        return result;
    }
}
