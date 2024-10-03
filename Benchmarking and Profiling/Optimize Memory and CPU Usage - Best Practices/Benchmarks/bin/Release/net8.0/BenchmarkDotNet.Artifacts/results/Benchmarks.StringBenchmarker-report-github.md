```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
AMD Ryzen 7 5700X, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method             | Mean           | Error        | StdDev       | Gen0         | Gen1         | Gen2         | Allocated   |
|------------------- |---------------:|-------------:|-------------:|-------------:|-------------:|-------------:|------------:|
| BuildString        | 2,640,998.9 μs | 52,172.11 μs | 65,981.01 μs | 9164000.0000 | 9133000.0000 | 9127000.0000 | 31460.39 MB |
| BuildStringBuilder |       522.1 μs |      7.99 μs |      7.47 μs |     199.2188 |     199.2188 |     199.2188 |     1.31 MB |
