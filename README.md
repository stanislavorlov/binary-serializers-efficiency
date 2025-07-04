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
| Method                                                       | Mean     | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------------------------- |---------:|----------:|----------:|-------:|----------:|
| MessagePackSerializationDeserialization_SimpleObject_Count_1 | 1.055 μs | 0.0071 μs | 0.0067 μs | 0.0420 |     712 B |
<!-- BENCHMARK_END -->
