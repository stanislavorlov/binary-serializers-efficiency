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
.NET SDK 8.0.412
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX2


```
| Method                                                              | Mean              | Error          | StdDev         | Gen0        | Gen1        | Gen2      | Allocated     |
|-------------------------------------------------------------------- |------------------:|---------------:|---------------:|------------:|------------:|----------:|--------------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1        |          1.028 μs |      0.0072 μs |      0.0068 μs |      0.0420 |           - |         - |         712 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10       |          8.500 μs |      0.0495 μs |      0.0439 μs |      0.4120 |           - |         - |        6976 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100      |         80.760 μs |      0.5109 μs |      0.4529 μs |      4.0283 |      0.4883 |         - |       69256 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000     |        812.909 μs |      3.8171 μs |      3.3837 μs |     41.0156 |     16.6016 |         - |      692056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_10000    |      9,068.242 μs |     65.8524 μs |     51.4132 μs |    359.3750 |    265.6250 |         - |     6920056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_100000   |    121,289.749 μs |  2,362.6016 μs |  2,209.9790 μs |   3000.0000 |   2000.0000 |         - |    69200056 B |
| MessagePackSerializationDeserialization_SimpleObject_Count_1000000  |  1,381,667.813 μs | 14,557.8191 μs | 12,905.1274 μs |  40000.0000 |  39000.0000 |         - |   766273856 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1       |          2.801 μs |      0.0140 μs |      0.0125 μs |      0.0954 |           - |         - |        1624 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10      |         25.456 μs |      0.1116 μs |      0.0989 μs |      0.9460 |      0.0305 |         - |       16120 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100     |        246.606 μs |      1.8535 μs |      1.7338 μs |      9.2773 |      1.4648 |         - |      160752 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000    |      2,502.324 μs |      8.1843 μs |      6.8343 μs |     74.2188 |     35.1563 |         - |     1607056 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_10000   |     27,706.213 μs |    230.0924 μs |    203.9709 μs |    750.0000 |    718.7500 |         - |    16070056 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_100000  |    302,009.543 μs |  2,309.7054 μs |  1,803.2661 μs |   8000.0000 |   7000.0000 |         - |   181227832 B |
| MessagePackSerializationDeserialization_ComplexObject_Count_1000000 |  3,945,771.958 μs | 54,083.5076 μs | 47,943.6208 μs |  95000.0000 |  94000.0000 | 1000.0000 |  1900816888 B |
| JsonSerializationDeserialization_SimpleObject_Count_1               |          5.269 μs |      0.0340 μs |      0.0284 μs |      0.3815 |           - |         - |        6496 B |
| JsonSerializationDeserialization_SimpleObject_Count_10              |         46.699 μs |      0.2056 μs |      0.1923 μs |      2.1362 |      0.0610 |         - |       36488 B |
| JsonSerializationDeserialization_SimpleObject_Count_100             |        453.650 μs |      1.9342 μs |      1.8092 μs |     17.5781 |      2.9297 |         - |      295288 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000            |      4,451.363 μs |     15.7646 μs |     13.1642 μs |    101.5625 |     31.2500 |         - |     2892808 B |
| JsonSerializationDeserialization_SimpleObject_Count_10000           |     54,911.651 μs |    392.4184 μs |    327.6872 μs |   1000.0000 |    444.4444 |         - |    28921480 B |
| JsonSerializationDeserialization_SimpleObject_Count_100000          |    590,469.014 μs |  5,748.1926 μs |  5,376.8629 μs |  10000.0000 |   9000.0000 |         - |   288551920 B |
| JsonSerializationDeserialization_SimpleObject_Count_1000000         |  6,128,334.306 μs | 42,856.5936 μs | 35,787.1966 μs | 103000.0000 | 102000.0000 | 1000.0000 |  2881179920 B |
| JsonSerializationDeserialization_ComplexObject_Count_1              |          9.181 μs |      0.0670 μs |      0.0627 μs |      0.6714 |           - |         - |       11240 B |
| JsonSerializationDeserialization_ComplexObject_Count_10             |         89.179 μs |      0.6256 μs |      0.5852 μs |      4.3945 |      0.2441 |         - |       75432 B |
| JsonSerializationDeserialization_ComplexObject_Count_100            |        844.111 μs |      2.9111 μs |      2.4309 μs |     24.4141 |      3.9063 |         - |      714424 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000           |      8,665.307 μs |     19.2218 μs |     17.0396 μs |    187.5000 |     78.1250 |         - |     6987744 B |
| JsonSerializationDeserialization_ComplexObject_Count_10000          |     89,523.197 μs |  1,650.1958 μs |  1,543.5941 μs |   1833.3333 |   1166.6667 |         - |    69919752 B |
| JsonSerializationDeserialization_ComplexObject_Count_100000         |    945,521.519 μs |  5,031.9612 μs |  4,706.8997 μs |  19000.0000 |  14000.0000 |         - |   698489640 B |
| JsonSerializationDeserialization_ComplexObject_Count_1000000        | 10,251,051.406 μs | 73,718.9937 μs | 65,349.9678 μs | 195000.0000 | 139000.0000 | 2000.0000 |  6980625720 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1           |          1.099 μs |      0.0047 μs |      0.0044 μs |      0.0343 |           - |         - |         584 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10          |          6.572 μs |      0.0215 μs |      0.0202 μs |      0.1450 |           - |         - |        2512 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100         |         64.724 μs |      0.3713 μs |      0.3473 μs |      2.6855 |      0.1221 |         - |       45200 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000        |        643.943 μs |      0.7871 μs |      0.6145 μs |      9.7656 |           - |         - |      395136 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_10000       |      6,795.889 μs |     15.3443 μs |     13.6023 μs |     31.2500 |           - |         - |     3448184 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_100000      |     66,199.099 μs |    223.3578 μs |    198.0009 μs |    125.0000 |           - |         - |    46722096 B |
| ProtobufSerializationDeserialization_SimpleObject_Count_1000000     |    665,904.604 μs |  1,882.3553 μs |  1,571.8520 μs |   2000.0000 |           - |         - |   402016792 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1          |          1.026 μs |      0.0070 μs |      0.0065 μs |      0.0343 |           - |         - |         592 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10         |          7.000 μs |      0.0305 μs |      0.0271 μs |      0.1450 |           - |         - |        2512 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100        |         63.513 μs |      0.5068 μs |      0.4740 μs |      2.6855 |      0.1221 |         - |       45176 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000       |        650.687 μs |      1.6964 μs |      1.4166 μs |      9.7656 |      0.9766 |         - |      394648 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_10000      |      6,873.498 μs |     14.8847 μs |     13.1949 μs |     31.2500 |           - |         - |     3448192 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_100000     |     74,877.518 μs |    831.1025 μs |    736.7507 μs |    142.8571 |           - |         - |    46705840 B |
| ProtobufSerializationDeserialization_ComplexObject_Count_1000000    |    693,106.515 μs |  2,387.7214 μs |  1,993.8555 μs |   2000.0000 |           - |         - |   402017312 B |
| AvroSerializationDeserialization_SimpleObject_Count_1               |          3.339 μs |      0.0171 μs |      0.0152 μs |      0.2861 |           - |         - |        4832 B |
| AvroSerializationDeserialization_SimpleObject_Count_10              |         30.648 μs |      0.2225 μs |      0.2081 μs |      2.6855 |           - |         - |       45216 B |
| AvroSerializationDeserialization_SimpleObject_Count_100             |        313.227 μs |      1.7561 μs |      1.5567 μs |     26.3672 |      3.4180 |         - |      445240 B |
| AvroSerializationDeserialization_SimpleObject_Count_1000            |      3,194.525 μs |     11.5707 μs |      9.6621 μs |    261.7188 |     93.7500 |         - |     4543040 B |
| AvroSerializationDeserialization_SimpleObject_Count_10000           |     48,804.810 μs |    620.9334 μs |    580.8215 μs |   2454.5455 |   1000.0000 |         - |    44999392 B |
| AvroSerializationDeserialization_SimpleObject_Count_100000          |    461,734.981 μs |  7,446.6926 μs |  6,601.2990 μs |  24000.0000 |   7000.0000 |         - |   445269048 B |
| AvroSerializationDeserialization_SimpleObject_Count_1000000         |  4,615,994.613 μs | 41,794.1418 μs | 34,900.0013 μs | 249000.0000 |  74000.0000 |         - |  4549150864 B |
| AvroSerializationDeserialization_ComplexObject_Count_1              |          9.232 μs |      0.0598 μs |      0.0530 μs |      0.6866 |           - |         - |       11592 B |
| AvroSerializationDeserialization_ComplexObject_Count_10             |         89.965 μs |      0.3105 μs |      0.2593 μs |      6.7139 |      0.2441 |         - |      113632 B |
| AvroSerializationDeserialization_ComplexObject_Count_100            |        898.106 μs |      6.5314 μs |      6.1095 μs |     66.4063 |     11.7188 |         - |     1116624 B |
| AvroSerializationDeserialization_ComplexObject_Count_1000           |      9,624.074 μs |     73.7980 μs |     65.4200 μs |    609.3750 |    234.3750 |         - |    11551408 B |
| AvroSerializationDeserialization_ComplexObject_Count_10000          |    125,300.153 μs |  2,300.4643 μs |  2,259.3636 μs |   6000.0000 |   2000.0000 |         - |   113509688 B |
| AvroSerializationDeserialization_ComplexObject_Count_100000         |  1,206,637.573 μs |  9,624.9644 μs |  9,003.1977 μs |  60000.0000 |  18000.0000 |         - |  1117787984 B |
| AvroSerializationDeserialization_ComplexObject_Count_1000000        | 13,464,503.154 μs | 95,196.8995 μs | 84,389.5718 μs | 610000.0000 | 189000.0000 | 2000.0000 | 11576332440 B |
<!-- BENCHMARK_END -->
