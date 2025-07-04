# Binary serialization

<img src="./img/microsoft-dot-net-icon.png" height="100" alt="Net8">
<img src="./img/BenchmarkDotNet.png" height="100" alt="BenchmarkDotNet">

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
<!-- Results will be inserted here -->
<!-- BENCHMARK_END -->
