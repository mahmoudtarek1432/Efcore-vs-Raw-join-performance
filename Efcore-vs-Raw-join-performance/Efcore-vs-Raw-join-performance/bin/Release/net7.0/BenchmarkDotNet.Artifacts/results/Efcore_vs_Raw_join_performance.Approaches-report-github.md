```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22000.2538/21H2/SunValley)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
| Method                | Mean    | Error   | StdDev  |
|---------------------- |--------:|--------:|--------:|
| BenchmarkEfExpression | 13.32 s | 0.255 s | 0.322 s |
