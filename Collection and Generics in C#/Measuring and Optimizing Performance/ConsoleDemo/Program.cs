using BenchmarkDotNet.Running;
using ConsoleDemo;

try
{
    BenchmarkRunner.Run<SortingBenchmark>();
}
catch (Exception e)
{
    Console.WriteLine($"ERROR: {e.Message}");
}