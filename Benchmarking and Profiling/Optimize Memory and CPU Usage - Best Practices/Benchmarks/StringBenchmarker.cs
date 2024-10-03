using BenchmarkDotNet.Attributes;
using System.Text;

namespace Benchmarks;

[SimpleJob]
[MemoryDiagnoser]
public class StringBenchmarker
{
    [Benchmark]
    public string BuildString()
    {
        string result = "";

        for (int i = 0; i< 50000; i++)
        {
            result = $"{result}{i}{Environment.NewLine}";
        }

        return result;
    }

    [Benchmark]
    public string BuildStringBuilder()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < 50000; i++)
        {
            builder.Append(i);
            builder.Append(Environment.NewLine);
        }

        return builder.ToString();
    }
}
