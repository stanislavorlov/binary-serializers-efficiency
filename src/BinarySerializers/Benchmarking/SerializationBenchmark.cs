using BenchmarkDotNet.Attributes;
using BinarySerializers.Contracts;
using BinarySerializers.DataContracts;
using BinarySerializers.Serializers;
using MessagePack;
using ProtoBuf;
using Avro;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using Avro.IO;

namespace BinarySerializers.Benchmarking;

[MemoryDiagnoser]
public class SerializationBenchmark
{
    private DataSource? _dataSource;
    private readonly Dictionary<int, DeviceTelemetry[]> _simpleObjects = [];
    private readonly Dictionary<int, Invoice[]> _complexObjects = [];
    private readonly int[] counts = [1, 10, 100, 1000, 10000, 100000, 1000000];

    [GlobalSetup]
    public void Setup()
    {
        // Setup a datasource up to 1000000 objects
        _dataSource = new DataSource();

        foreach (var count in counts)
        {
            var simples = _dataSource.GetSimpleObjects(count);
            var complexes = _dataSource.GetComplexObjects(count);

            _simpleObjects.Add(count, [.. simples]);
            _complexObjects.Add(count, [.. complexes]);
        }
    }

    #region MessagePack

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_1()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry), _simpleObjects[1].First());
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_10()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[10]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_100()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[100]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_1000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[1000]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_10000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[10000]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_100000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[100000]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_SimpleObject_Count_1000000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(DeviceTelemetry[]), _simpleObjects[1000000]);
        var deserializedItem = MessagePackSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_1()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice), _complexObjects[1].First());
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_10()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[10]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_100()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[100]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_1000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[1000]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_10000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[10000]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_100000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[100000]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    [Benchmark]
    public void MessagePackSerializationDeserialization_ComplexObject_Count_1000000()
    {
        var serializedBytes = MessagePackSerializer.Serialize(typeof(Invoice[]), _complexObjects[1000000]);
        var deserializedItem = MessagePackSerializer.Deserialize<Invoice[]>(serializedBytes);
    }

    #endregion

    #region JSON

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_1()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[1].First());
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_10()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[10]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_100()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[100]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_1000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[1000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_10000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[10000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_100000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[100000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_SimpleObject_Count_1000000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_simpleObjects[1000000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_1()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[1].First());
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_10()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[10]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_100()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[100]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_1000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[1000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_10000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[10000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_100000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[100000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    [Benchmark]
    public void JsonSerializationDeserialization_ComplexObject_Count_1000000()
    {
        var serializedBytes = JsonSerializer.SerializeToUtf8Bytes(_complexObjects[1000000]);
        var deserialized = JsonSerializer.Deserialize<DeviceTelemetry[]>(serializedBytes);
    }

    #endregion

    #region Protobuf

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_1()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1].First());
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<DeviceTelemetry>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_10()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[10]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_100()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[100]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_1000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_10000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[10000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_100000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[100000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_SimpleObject_Count_1000000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1000000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetries = Serializer.Deserialize<DeviceTelemetry[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_1()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1].First());
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_10()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[10]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_100()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[100]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_1000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_10000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[10000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_100000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[100000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    [Benchmark]
    public void ProtobufSerializationDeserialization_ComplexObject_Count_1000000()
    {
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, _simpleObjects[1000000]);
        protoSerialized = stream.ToArray();

        var deviceTelemetry = Serializer.Deserialize<Invoice[]>(stream);
    }

    #endregion

    #region Apache Avro

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_1()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObject(_simpleObjects[1].First());
        var deserializedItem = AvroSerializer.DeserializeSimpleObject(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_10()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[10].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_100()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[100].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_1000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[1000].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_10000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[10000].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_100000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[100000].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_SimpleObject_Count_1000000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeSimpleObjectList(_simpleObjects[1000000].ToList());
        var deserializedItem = AvroSerializer.DeserializeSimpleObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_1()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObject(_complexObjects[1].First());
        var deserializedItem = AvroSerializer.DeserializeComplexObject(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_10()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[10].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_100()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[100].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_1000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[1000].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_10000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[10000].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_100000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[100000].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    [Benchmark]
    public void AvroSerializationDeserialization_ComplexObject_Count_1000000()
    {
        byte[] serializedBytes = AvroSerializer.SerializeComplexObjectList(_complexObjects[1000000].ToList());
        var deserializedItem = AvroSerializer.DeserializeComplexObjectList(serializedBytes);
    }

    #endregion
}
