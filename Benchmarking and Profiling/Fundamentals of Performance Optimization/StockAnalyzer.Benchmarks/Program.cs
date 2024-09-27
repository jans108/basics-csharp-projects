using BenchmarkDotNet.Running;
using StockAnalyzer.Processor;
using System.Diagnostics;

BenchmarkRunner.Run<ProcessorBenchmarks>();