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


### Compression size

<!-- COMPRESSION_START -->

| | | | | |
| -- | -- | -- | -- | -- |
| | JSON | MessagePack | Protobuf | Avro |
| Simple Object| | | | |
| 1 | 230 | 84 | 98 | 80 |
| 10 | 2283 | 841 | 998 | 799 |
| 100 | 22839 | 8403 | 9989 | 7994 |
| 1000 | 228236 | 84003 | 99870 | 79927 |
| 10000 | 2282603 | 840003 | 998787 | 799362 |
| 100000 | 22827328 | 8400001 | 9987516 | 7993727 |
| 1000000 | 228271082 | 83999959 | 99873505 | 79936887 |
| Complex Object | | | | |
| 1 | 743 | 303 | 332 | 294 |
| 10 | 7424 | 3031 | 3348 | 2938 |
| 100 | 74238 | 30303 | 33467 | 29379 |
| 1000 | 742390 | 303001 | 334614 | 293805 |
| 10000 | 7424486 | 3029995 | 3346115 | 2938091 |
| 100000 | 74244660 | 30299979 | 33462036 | 29381276 |
| 1000000 | 742445802 | 302999847 | 334621528 | 293810928 |
<!-- COMPRESSION_END -->

### 📊 Benchmark Results

<!-- BENCHMARK_START -->

```

BenchmarkDotNet v0.15.2, Linux Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 8.0.412
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                                                              | Mean                | Error            | StdDev           | Gen0        | Gen1        | Gen2      | Allocated     |
|-------------------------------------------------------------------- |--------------------:|-----------------:|-----------------:|------------:|------------:|----------:|--------------:|
| MessagePackSerializationDeserialization_ComplexObject_Count_100     |        240,321.0 ns |        509.87 ns |        425.77 ns |      9.5215 |      1.9531 |         - |      160752 B |
| JsonSerializationDeserialization_ComplexObject_Count_100            |        824,748.2 ns |      1,156.87 ns |        966.04 ns |     24.4141 |      3.9063 |         - |      714456 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100        |         64,439.5 ns |        262.18 ns |        218.93 ns |      2.6855 |      0.1221 |         - |       45192 B |
| AvroSerializationDeserialization_ComplexObject_Count_100            |        893,266.8 ns |      3,306.23 ns |      2,930.88 ns |     66.4063 |     11.7188 |         - |     1116632 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100000  |    310,531,761.2 ns |  1,116,790.29 ns |    932,570.47 ns |   8500.0000 |   8000.0000 |         - |   181227832 B |
| JsonSerializationDeserialization_ComplexObject_Count_100000         |    965,359,137.0 ns |  3,496,895.23 ns |  3,270,997.97 ns |  19000.0000 |  14000.0000 |         - |   698490120 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100000     |     67,919,952.6 ns |    201,726.56 ns |    157,494.83 ns |    125.0000 |           - |         - |    46787536 B |
| AvroSerializationDeserialization_ComplexObject_Count_100000         |  1,239,873,199.4 ns | 11,078,581.78 ns |  9,820,874.19 ns |  60000.0000 |  18000.0000 |         - |  1117787712 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000000 |  3,861,983,840.9 ns | 20,054,412.68 ns | 17,777,714.49 ns |  95000.0000 |  94000.0000 | 1000.0000 |  1900816872 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000000        | 10,783,557,740.6 ns | 66,002,593.91 ns | 58,509,580.35 ns | 196000.0000 | 140000.0000 | 3000.0000 |  6980630312 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000000    |    672,950,444.4 ns |  2,076,791.70 ns |  1,841,021.75 ns |   2000.0000 |           - |         - |   401755272 B |
| AvroSerializationDeserialization_ComplexObject_Count_1000000        | 13,246,646,802.6 ns | 46,462,491.59 ns | 41,187,788.60 ns | 610000.0000 | 189000.0000 | 2000.0000 | 11576332448 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1       |          2,804.4 ns |          4.58 ns |          3.83 ns |      0.0954 |           - |         - |        1624 B |
| JsonSerializationDeserialization_ComplexObject_Count_1              |          9,343.7 ns |         68.54 ns |         64.12 ns |      0.6714 |           - |         - |       11240 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1          |            996.3 ns |          2.96 ns |          2.47 ns |      0.0343 |           - |         - |         592 B |
| AvroSerializationDeserialization_ComplexObject_Count_1              |          9,283.8 ns |         40.59 ns |         33.90 ns |      0.6866 |           - |         - |       11592 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10      |         25,206.7 ns |        133.53 ns |        118.37 ns |      0.9460 |      0.0305 |         - |       16120 B |
| JsonSerializationDeserialization_ComplexObject_Count_10             |         86,159.8 ns |        252.17 ns |        223.54 ns |      4.3945 |      0.2441 |         - |       75448 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10         |          6,832.9 ns |         11.73 ns |         10.40 ns |      0.1450 |           - |         - |        2512 B |
| AvroSerializationDeserialization_ComplexObject_Count_10             |         90,353.4 ns |        175.39 ns |        146.46 ns |      6.7139 |      0.2441 |         - |      113632 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10000   |     27,760,810.6 ns |    143,016.31 ns |    111,657.73 ns |    750.0000 |    718.7500 |         - |    16070056 B |
| JsonSerializationDeserialization_ComplexObject_Count_10000          |     90,203,890.7 ns |  1,760,590.56 ns |  2,095,858.01 ns |   1833.3333 |   1166.6667 |         - |    69920048 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10000      |      6,832,330.1 ns |     15,529.66 ns |     13,766.64 ns |     31.2500 |           - |         - |     3444080 B |
| AvroSerializationDeserialization_ComplexObject_Count_10000          |    122,865,204.6 ns |    792,734.68 ns |    661,969.36 ns |   6000.0000 |   2000.0000 |         - |   113509664 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000    |      2,437,922.1 ns |      6,599.94 ns |      5,850.67 ns |     74.2188 |     35.1563 |         - |     1607056 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000           |      8,602,470.3 ns |     25,499.70 ns |     22,604.82 ns |    187.5000 |     78.1250 |         - |     6987864 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000       |        649,382.4 ns |      1,779.70 ns |      1,486.13 ns |      9.7656 |           - |         - |      395168 B |
| AvroSerializationDeserialization_ComplexObject_Count_1000           |      9,552,391.5 ns |     44,612.11 ns |     39,547.48 ns |    609.3750 |    234.3750 |         - |    11551408 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100      |         78,355.1 ns |        270.21 ns |        225.63 ns |      4.0283 |      0.4883 |         - |       69256 B |
| JsonSerializationDeserialization_SimpleObject_Count_100             |        435,953.1 ns |      2,141.57 ns |      2,003.23 ns |     17.5781 |      3.4180 |         - |      295392 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100         |         65,682.7 ns |        518.68 ns |        485.17 ns |      2.6855 |      0.1221 |         - |       45192 B |
| AvroSerializationDeserialization_SimpleObject_Count_100             |        308,905.3 ns |      2,871.64 ns |      2,686.13 ns |     26.3672 |      2.9297 |         - |      445248 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100000   |    118,350,708.3 ns |  1,715,911.65 ns |  1,521,110.99 ns |   3000.0000 |   2000.0000 |         - |    69200048 B |
| JsonSerializationDeserialization_SimpleObject_Count_100000          |    574,957,160.9 ns |  3,435,430.48 ns |  3,045,419.64 ns |  10000.0000 |   9000.0000 |         - |   288555104 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100000      |     67,337,830.8 ns |    252,638.97 ns |    223,957.87 ns |    125.0000 |           - |         - |    46787624 B |
| AvroSerializationDeserialization_SimpleObject_Count_100000          |    474,202,446.4 ns |  9,417,712.64 ns | 17,918,178.47 ns |  24000.0000 |   7000.0000 |         - |   445268992 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000000  |  1,367,797,111.1 ns |  6,013,842.42 ns |  4,695,212.59 ns |  40000.0000 |  39000.0000 |         - |   766273856 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000000         |  6,286,133,486.9 ns | 50,943,883.64 ns | 45,160,425.93 ns | 103000.0000 | 102000.0000 | 1000.0000 |  2881196888 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000000     |    654,426,224.5 ns |  1,956,358.08 ns |  1,734,260.48 ns |   2000.0000 |           - |         - |   402279624 B |
| AvroSerializationDeserialization_SimpleObject_Count_1000000         |  5,121,764,397.6 ns | 90,323,367.42 ns | 84,488,533.97 ns | 249000.0000 |  74000.0000 |         - |  4549150744 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1        |          1,023.8 ns |          4.13 ns |          3.45 ns |      0.0420 |           - |         - |         712 B |
| JsonSerializationDeserialization_SimpleObject_Count_1               |          5,426.0 ns |         63.51 ns |         59.41 ns |      0.3815 |           - |         - |        6480 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1           |          1,027.2 ns |          5.79 ns |          5.41 ns |      0.0343 |           - |         - |         584 B |
| AvroSerializationDeserialization_SimpleObject_Count_1               |          3,376.9 ns |         28.34 ns |         22.12 ns |      0.2861 |           - |         - |        4832 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10       |          8,600.1 ns |         45.68 ns |         42.73 ns |      0.4120 |           - |         - |        6976 B |
| JsonSerializationDeserialization_SimpleObject_Count_10              |         46,620.7 ns |        185.21 ns |        164.18 ns |      2.1362 |           - |         - |       36504 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10          |          6,599.0 ns |         22.25 ns |         19.72 ns |      0.1450 |           - |         - |        2512 B |
| AvroSerializationDeserialization_SimpleObject_Count_10              |         32,419.8 ns |        414.20 ns |        387.44 ns |      2.6855 |           - |         - |       45216 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10000    |      9,169,889.2 ns |    141,500.06 ns |    132,359.24 ns |    359.3750 |    265.6250 |         - |     6920048 B |
| JsonSerializationDeserialization_SimpleObject_Count_10000           |     55,004,938.9 ns |    376,096.61 ns |    314,057.70 ns |   1000.0000 |    444.4444 |         - |    28919304 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10000       |      7,494,278.9 ns |    100,415.58 ns |     89,015.79 ns |     31.2500 |           - |         - |     3438928 B |
| AvroSerializationDeserialization_SimpleObject_Count_10000           |     51,772,895.5 ns |  1,001,855.98 ns |  1,468,507.63 ns |   2500.0000 |   1000.0000 |         - |    44999448 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000     |        867,255.3 ns |      1,197.72 ns |      1,000.15 ns |     41.0156 |     16.6016 |         - |      692056 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000            |      4,550,053.7 ns |      9,716.05 ns |      8,613.03 ns |    101.5625 |     31.2500 |         - |     2892048 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000        |        691,179.5 ns |      1,278.12 ns |      1,067.29 ns |      9.7656 |           - |         - |      395432 B |
| AvroSerializationDeserialization_SimpleObject_Count_1000            |      3,263,266.9 ns |     20,273.73 ns |     18,964.06 ns |    261.7188 |     93.7500 |         - |     4543048 B |
<!-- BENCHMARK_END -->
