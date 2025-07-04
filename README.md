```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.411
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2


```
| Method                                                        | Mean             | Error          | StdDev         | Gen0       | Gen1       | Allocated   |
|-------------------------------------------------------------- |-----------------:|---------------:|---------------:|-----------:|-----------:|------------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1  |         1.031 μs |      0.0112 μs |      0.0100 μs |     0.0420 |          - |       712 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10 | 1,355,487.634 μs | 14,447.1183 μs | 12,806.9941 μs | 40000.0000 | 39000.0000 | 766266960 B |
