using BenchmarkDotNet.Running;
using Benchmarks;

BenchmarkRunner.Run<StringBenchmarker>();

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();