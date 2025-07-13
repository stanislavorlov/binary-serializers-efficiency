// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using BinarySerializers.Benchmarking;

//---------------------- Run Benchmark ------------------------------------
var summary = BenchmarkRunner.Run<SerializationBenchmark>();

Console.WriteLine("Benchmark summary is ready");