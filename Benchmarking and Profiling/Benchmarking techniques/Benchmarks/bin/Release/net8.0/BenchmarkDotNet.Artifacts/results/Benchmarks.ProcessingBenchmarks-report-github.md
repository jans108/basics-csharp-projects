```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4169/23H2/2023Update/SunValley3)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.400
  [Host]               : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2 [AttachedDebugger]
  .NET 8.0             : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  .NET Framework 4.7.2 : .NET Framework 4.8.1 (4.8.9261.0), X64 RyuJIT VectorSize=256


```
| Method    | Job                  | Runtime              | Mean     | Error   | StdDev  | Ratio |
|---------- |--------------------- |--------------------- |---------:|--------:|--------:|------:|
| Calculate | .NET 8.0             | .NET 8.0             | 509.1 ms | 5.37 ms | 5.02 ms |  1.00 |
| Calculate | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 507.9 ms | 5.57 ms | 5.21 ms |  1.00 |
