```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 7 5700X, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                  | Mean              | Error            | StdDev           | Gen0       | Gen1      | Allocated   |
|------------------------ |------------------:|-----------------:|-----------------:|-----------:|----------:|------------:|
| Process                 |          12.65 ns |         0.274 ns |         0.393 ns |     0.0019 |         - |        32 B |
| Processor               | 183,119,302.22 ns | 1,552,524.842 ns | 1,452,232.701 ns |          - |         - |    606213 B |
| ProcessorFaster         |     631,724.42 ns |     2,769.661 ns |     2,455.232 ns |    24.4141 |    9.7656 |    420568 B |
| ProcessorFasterAsync    | 335,411,323.08 ns | 1,331,150.249 ns | 1,111,570.746 ns | 17000.0000 | 1000.0000 | 287866936 B |
| ProcessorFasterAsync_V2 | 903,228,166.67 ns | 3,528,918.936 ns | 3,300,952.964 ns | 17000.0000 | 1000.0000 | 287867752 B |
