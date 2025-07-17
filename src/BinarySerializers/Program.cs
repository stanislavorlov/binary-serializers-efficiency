// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using BinarySerializers.Benchmarking;

Console.WriteLine("Generating size comparison report");

SerializationCompression.CompareSize_Of_Binary_To_JSON();

Console.WriteLine("Size comparison report is ready");

//---------------------- Run Benchmark ------------------------------------
Console.WriteLine("Running Benchmark");

var summary = BenchmarkRunner.Run<SerializationBenchmark>();

Console.WriteLine("Benchmark summary is ready");