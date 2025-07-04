# Binary serialization benchmarks

<p align="left">
  <img src="./img/microsoft-dot-net-icon.png" style="height: 100px;" alt="Net8">
  <img src="./img/BenchmarkDotNet.png" style="height: 100px;" alt="BenchmarkDotNet">
</p>

Comparison analysis of Binary and Text serializers using .Net Benchmarking on different data type objects.
The following formats are considered during the benchmarking:
- **JSON** is used as lightweight data-interchange format that is easy for humans to read and write (text-based format).
- **Protocol Buffer (Protobuf)** is a popular serialization format developed by Google emphasized by its simplicity and performance.
- **MessagePack** is an extremely efficient serialized format, which represents serialized data in structures like arrays and associated arrays.

## Prerequisites for local run
- .Net 8 (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

## How to run locally
- Navigate to `src\BinarySerializers` folder
- Build the solution using a Release configuration `dotnet build -c Release`
- Run a Benchmarking project using a Release configuration `dotnet run -c Release`
- Navigate to `BenchmarkDotNet.Artifacts` folder and obtain results or check the Console

## Comparison results

| Serialization size    | Serialization speed |
| -------- | ------- |
| <img src="./img/Size comparison.png" style="height: 500px" alt="Message size">  | <img src="./img/Speed comparison.png" style="height: 500px" alt="Serialization speed"> |


## 📊 Benchmark Results

<!-- BENCHMARK_START -->

```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.411
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2


```
| Method                                                              | Mean                | Error            | StdDev           | Gen0        | Gen1        | Gen2      | Allocated    |
|-------------------------------------------------------------------- |--------------------:|-----------------:|-----------------:|------------:|------------:|----------:|-------------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1        |          1,049.5 ns |          8.95 ns |          7.94 ns |      0.0420 |           - |         - |        712 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10       |          9,135.7 ns |         56.12 ns |         49.75 ns |      0.4120 |           - |         - |       6976 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100      |         87,624.8 ns |        578.61 ns |        512.92 ns |      4.0283 |      0.4883 |         - |      69256 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000     |        828,256.2 ns |      5,467.30 ns |      4,846.62 ns |     41.0156 |     16.6016 |         - |     692056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10000    |      9,844,625.2 ns |    178,477.23 ns |    166,947.71 ns |    359.3750 |    265.6250 |         - |    6920056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100000   |    123,003,550.0 ns |  2,104,732.87 ns |  1,865,790.87 ns |   3000.0000 |   2000.0000 |         - |   69200056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000000  |  1,414,193,227.3 ns | 18,618,074.94 ns | 16,504,438.50 ns |  40000.0000 |  39000.0000 |         - |  766273880 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1       |          2,881.9 ns |         17.71 ns |         16.56 ns |      0.0954 |           - |         - |       1624 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10      |         26,249.9 ns |        161.88 ns |        151.42 ns |      0.9460 |      0.0305 |         - |      16120 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100     |        248,773.2 ns |      1,100.78 ns |        975.81 ns |      9.2773 |      1.4648 |         - |     160752 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000    |      2,514,969.0 ns |     20,788.73 ns |     18,428.67 ns |     74.2188 |     35.1563 |         - |    1607056 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10000   |     28,344,274.6 ns |    242,922.50 ns |    215,344.47 ns |    750.0000 |    718.7500 |         - |   16070056 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100000  |    304,101,010.1 ns |  2,466,473.38 ns |  2,059,616.98 ns |   8000.0000 |   7000.0000 |         - |  181227832 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000000 |  4,031,995,860.2 ns | 20,401,065.09 ns | 18,085,012.82 ns |  95000.0000 |  94000.0000 | 1000.0000 | 1900816872 B |
| JsonSerializationDeserialization_SimpleObject_Count_1               |          5,555.9 ns |         40.83 ns |         36.19 ns |      0.3815 |           - |         - |       6496 B |
| JsonSerializationDeserialization_SimpleObject_Count_10              |         48,755.6 ns |        233.72 ns |        207.18 ns |      2.1362 |      0.0610 |         - |      36520 B |
| JsonSerializationDeserialization_SimpleObject_Count_100             |        450,593.8 ns |      3,264.88 ns |      2,894.23 ns |     17.5781 |      3.4180 |         - |     295360 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000            |      4,550,215.4 ns |     32,095.87 ns |     28,452.15 ns |    101.5625 |     31.2500 |         - |    2892968 B |
| JsonSerializationDeserialization_SimpleObject_Count_10000           |     56,765,115.1 ns |    412,356.87 ns |    365,543.63 ns |   1000.0000 |    444.4444 |         - |   28922648 B |
| JsonSerializationDeserialization_SimpleObject_Count_100000          |    614,503,896.5 ns |  6,493,642.33 ns |  5,422,485.45 ns |  10000.0000 |   9000.0000 |         - |  288549992 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000000         |  6,486,839,012.4 ns | 73,151,685.29 ns | 64,847,063.65 ns | 103000.0000 | 102000.0000 | 1000.0000 | 2881195104 B |
| JsonSerializationDeserialization_ComplexObject_Count_1              |          9,645.1 ns |         53.83 ns |         47.72 ns |      0.6714 |           - |         - |      11240 B |
| JsonSerializationDeserialization_ComplexObject_Count_10             |         90,233.3 ns |        755.02 ns |        706.25 ns |      4.3945 |      0.2441 |         - |      75448 B |
| JsonSerializationDeserialization_ComplexObject_Count_100            |        878,818.8 ns |      4,378.87 ns |      3,656.55 ns |     24.4141 |      3.9063 |         - |     714424 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000           |      8,804,818.5 ns |     51,018.29 ns |     45,226.38 ns |    187.5000 |     78.1250 |         - |    6987704 B |
| JsonSerializationDeserialization_ComplexObject_Count_10000          |     91,776,520.6 ns |  1,604,877.77 ns |  1,717,201.23 ns |   1833.3333 |   1166.6667 |         - |   69919552 B |
| JsonSerializationDeserialization_ComplexObject_Count_100000         |    975,405,495.3 ns |  6,213,584.14 ns |  5,812,190.47 ns |  19000.0000 |  14000.0000 |         - |  698491712 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000000        | 10,229,448,419.1 ns | 91,892,895.69 ns | 81,460,658.53 ns | 195000.0000 | 139000.0000 | 2000.0000 | 6980600400 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1           |            989.5 ns |          4.99 ns |          4.43 ns |      0.0343 |           - |         - |        584 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10          |          6,901.9 ns |         42.99 ns |         40.21 ns |      0.1450 |           - |         - |       2512 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100         |         67,752.7 ns |        219.92 ns |        183.64 ns |      2.6855 |           - |         - |      45248 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000        |        660,229.6 ns |        878.43 ns |        685.82 ns |      9.7656 |           - |         - |     395168 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10000       |      6,859,313.0 ns |     21,520.61 ns |     16,801.88 ns |     31.2500 |           - |         - |    3444040 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100000      |     68,908,098.0 ns |    636,144.25 ns |    563,925.31 ns |    142.8571 |           - |         - |   46754856 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000000     |    672,166,787.7 ns |  2,746,282.08 ns |  2,293,269.92 ns |   2000.0000 |           - |         - |  401754872 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1          |          1,038.0 ns |          6.88 ns |          5.74 ns |      0.0343 |           - |         - |        592 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10         |          7,144.9 ns |         26.72 ns |         24.99 ns |      0.1450 |           - |         - |       2512 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100        |         63,930.1 ns |        879.68 ns |        779.81 ns |      2.6855 |      0.1221 |         - |      45200 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000       |        650,181.6 ns |      3,253.63 ns |      2,716.92 ns |      9.7656 |           - |         - |     394912 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10000      |      6,452,627.0 ns |     50,703.64 ns |     39,586.06 ns |     31.2500 |           - |         - |    3446056 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100000     |     66,958,098.2 ns |    258,773.85 ns |    202,033.60 ns |    125.0000 |           - |         - |   46787496 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000000    |    651,326,346.2 ns |  2,509,392.99 ns |  1,959,168.99 ns |   2000.0000 |           - |         - |  401755136 B |
<!-- BENCHMARK_END -->
