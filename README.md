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

## 📊 Benchmark Results

<!-- BENCHMARK_START -->

```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.411
  [Host]     : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.17 (8.0.1725.26602), X64 RyuJIT AVX2


```
| Method                                                              | Mean                | Error             | StdDev            | Gen0        | Gen1        | Gen2      | Allocated    |
|-------------------------------------------------------------------- |--------------------:|------------------:|------------------:|------------:|------------:|----------:|-------------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1        |          1,049.5 ns |           7.71 ns |           6.44 ns |      0.0420 |           - |         - |        712 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10       |  1,387,535,460.8 ns |   9,818,861.42 ns |   7,665,921.14 ns |  40000.0000 |  39000.0000 |         - |  766266952 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100      |  1,426,105,557.6 ns |  14,879,545.32 ns |  13,190,329.37 ns |  40000.0000 |  39000.0000 |         - |  766171888 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000     |  1,401,436,052.4 ns |  11,412,141.08 ns |   9,529,654.67 ns |  40000.0000 |  39000.0000 |         - |  765483496 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10000    |  1,395,758,099.3 ns |  11,086,603.27 ns |   9,827,985.03 ns |  39000.0000 |  38000.0000 |         - |  758501272 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100000   |  1,224,741,361.8 ns |  16,566,391.05 ns |  14,685,674.17 ns |  36000.0000 |  35000.0000 |         - |  688646344 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000000  |            166.2 ns |           0.92 ns |           0.82 ns |      0.0019 |           - |         - |         32 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1       |          2,782.4 ns |          12.37 ns |          10.97 ns |      0.0954 |           - |         - |       1624 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10      |  4,002,290,542.6 ns |  34,246,483.64 ns |  28,597,364.88 ns |  95000.0000 |  94000.0000 | 1000.0000 | 1900800824 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100     |  4,100,979,361.4 ns |  33,202,332.35 ns |  29,433,002.82 ns |  95000.0000 |  94000.0000 | 1000.0000 | 1900623448 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000    |  4,081,286,119.9 ns |  24,337,795.78 ns |  21,574,822.04 ns |  95000.0000 |  94000.0000 | 1000.0000 | 1898881984 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10000   |  4,042,221,382.2 ns |  36,024,711.18 ns |  31,934,968.14 ns |  95000.0000 |  94000.0000 | 1000.0000 | 1881697232 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100000  |  3,721,516,643.4 ns |  30,001,197.05 ns |  26,595,279.75 ns |  86000.0000 |  85000.0000 | 1000.0000 | 1709751464 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000000 |            167.1 ns |           0.68 ns |           0.63 ns |      0.0019 |           - |         - |         32 B |
| JsonSerializationDeserialization_SimpleObject_Count_1               |          5,549.4 ns |          52.65 ns |          49.25 ns |      0.3815 |           - |         - |       6496 B |
| JsonSerializationDeserialization_SimpleObject_Count_10              |  6,339,385,435.7 ns |  47,121,070.58 ns |  39,348,228.07 ns | 103000.0000 | 102000.0000 | 1000.0000 | 2881154440 B |
| JsonSerializationDeserialization_SimpleObject_Count_100             |  6,343,732,962.9 ns |  62,741,509.41 ns |  55,618,713.89 ns | 103000.0000 | 102000.0000 | 1000.0000 | 2880913368 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000            |  6,472,918,056.3 ns |  40,584,323.92 ns |  35,976,946.07 ns | 103000.0000 | 102000.0000 | 1000.0000 | 2878339248 B |
| JsonSerializationDeserialization_SimpleObject_Count_10000           |  6,385,097,099.9 ns |  33,919,137.36 ns |  30,068,431.79 ns | 102000.0000 | 101000.0000 | 1000.0000 | 2852552072 B |
| JsonSerializationDeserialization_SimpleObject_Count_100000          |  5,767,658,327.4 ns |  87,405,781.72 ns |  77,482,948.87 ns |  93000.0000 |  92000.0000 | 1000.0000 | 2594745696 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000000         |            671.9 ns |          12.47 ns |          11.05 ns |      0.1812 |      0.0010 |         - |       3032 B |
| JsonSerializationDeserialization_ComplexObject_Count_1              |          9,246.3 ns |          70.56 ns |          66.00 ns |      0.6561 |           - |         - |      11224 B |
| JsonSerializationDeserialization_ComplexObject_Count_10             | 10,303,713,701.1 ns | 106,781,448.00 ns |  94,658,972.35 ns | 195000.0000 | 139000.0000 | 2000.0000 | 6980549208 B |
| JsonSerializationDeserialization_ComplexObject_Count_100            | 10,480,796,424.6 ns |  80,424,892.81 ns |  71,294,572.67 ns | 195000.0000 | 139000.0000 | 2000.0000 | 6979918240 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000           | 10,203,805,268.8 ns |  87,060,411.67 ns |  77,176,787.31 ns | 195000.0000 | 139000.0000 | 2000.0000 | 6973626032 B |
| JsonSerializationDeserialization_ComplexObject_Count_10000          | 10,267,287,626.1 ns | 119,996,895.28 ns | 106,374,122.14 ns | 193000.0000 | 138000.0000 | 2000.0000 | 6910950960 B |
| JsonSerializationDeserialization_ComplexObject_Count_100000         |  9,440,313,371.4 ns |  91,481,381.50 ns |  81,095,861.92 ns | 176000.0000 | 125000.0000 | 2000.0000 | 6284239280 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000000        |            700.2 ns |           9.89 ns |           8.26 ns |      0.1812 |      0.0010 |         - |       3032 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1           |          1,127.7 ns |           3.92 ns |           3.47 ns |      0.0343 |           - |         - |        584 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10          |    667,702,831.7 ns |   4,424,876.86 ns |   4,139,032.57 ns |   2000.0000 |           - |         - |  401753720 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100         |    643,306,047.3 ns |   2,145,686.56 ns |   1,902,095.24 ns |   2000.0000 |           - |         - |  402003224 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000        |    662,006,285.2 ns |   5,913,771.46 ns |   5,242,404.36 ns |   2000.0000 |           - |         - |  401615288 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10000       |    659,896,123.5 ns |   4,935,940.47 ns |   4,617,081.78 ns |   2000.0000 |           - |         - |  400880568 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100000      |    593,332,869.7 ns |   5,022,682.10 ns |   4,698,219.95 ns |   2000.0000 |           - |         - |  388029872 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000000     |            312.7 ns |           0.71 ns |           0.63 ns |      0.0038 |           - |         - |         64 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1          |          1,165.7 ns |           5.76 ns |           5.39 ns |      0.0343 |           - |         - |        592 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10         |    666,192,725.8 ns |   4,048,919.24 ns |   3,589,261.45 ns |   2000.0000 |           - |         - |  402277640 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100        |    668,843,672.9 ns |   3,162,798.84 ns |   2,958,484.00 ns |   2000.0000 |           - |         - |  402265896 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000       |    659,719,939.3 ns |   3,432,912.68 ns |   2,866,637.57 ns |   2000.0000 |           - |         - |  402140008 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10000      |    664,385,578.7 ns |   1,999,064.21 ns |   1,669,309.15 ns |   2000.0000 |           - |         - |  400619240 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100000     |    587,039,216.5 ns |   2,809,102.96 ns |   2,345,728.20 ns |   2000.0000 |           - |         - |  387505352 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000000    |            345.1 ns |           1.13 ns |           1.00 ns |      0.0038 |           - |         - |         64 B |
<!-- BENCHMARK_END -->
