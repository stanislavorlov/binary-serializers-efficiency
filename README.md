```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.411
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2


```
| Method                                                       | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1 | 1.033 μs | 0.0075 μs | 0.0067 μs | 0.0420 |     712 B |
