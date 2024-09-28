using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmarks;

[SimpleJob(RuntimeMoniker.Net80, baseline:true)]
[SimpleJob(RuntimeMoniker.Net472)]
public class ProcessingBenchmarks
{
    [Benchmark]
    public string Calculate()
    {
        Thread.Sleep(500);

        return "Avoid JIT elimination";
    }
}
