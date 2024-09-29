using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[SimpleJob(RunStrategy.ColdStart, RuntimeMoniker.Net80, iterationCount: 10)]
[MemoryDiagnoser]
public class ProcessingBenchmarks
{

    [Benchmark(Baseline = true)]
    public string Calculate()
    {
        Thread.Sleep(Random.Shared.Next(500, 1000));

        return "Avoid JIT elimination";
    }

}
