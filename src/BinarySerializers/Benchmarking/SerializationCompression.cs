using BinarySerializers.Contracts;
using BinarySerializers.DataContracts;
using BinarySerializers.Serializers;
using MessagePack;
using ProtoBuf;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BinarySerializers.Benchmarking;

public class SerializationCompression
{
    public static void CompareSize_Of_Binary_To_JSON_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();

        var deviceTelemetries = dataSource.GetSimpleObjects(1);
        var deviceTelemetry = deviceTelemetries.First();

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(DeviceTelemetry), deviceTelemetry);

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetry);
        protoSerialized = stream.ToArray();

        //-----------------------Avro--------------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObject(deviceTelemetry);

        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //230
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //84
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //98
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_1000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObjectList(deviceTelemetries);

        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //84003
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //228304
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");
    }

    public static void CompareSize_Of_Binary_To_JSON_10000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();
        var deviceTelemetries = dataSource.GetSimpleObjects(10000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //2282627

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //840003

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //998742

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObjectList(deviceTelemetries);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");
    }

    public static void CompareSize_Of_Binary_To_JSON_100000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();
        var deviceTelemetries = dataSource.GetSimpleObjects(100000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //22827104

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //8400003

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //99874447

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObjectList(deviceTelemetries);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_1000000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //228270604

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //83999941

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObjectList(deviceTelemetries);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();
        var invoices = dataSource.GetComplexObjects(1);
        var invoice = invoices.FirstOrDefault();

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoice);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //744

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(Invoice), invoice);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //303

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoice);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //335

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObject(invoice);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_1000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new();
        var invoices = dataSource.GetComplexObjects(1000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //742419

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), invoices);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //303003

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObjectList(invoices);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //

    }

    public static void CompareSize_Of_Binary_To_JSON_10000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());
        DataSource dataSource = new();
        var invoices = dataSource.GetComplexObjects(10000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //7424503

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), invoices);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //3029999

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObjectList(invoices);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_100000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());
        DataSource dataSource = new();
        var invoices = dataSource.GetComplexObjects(100000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //74244775

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), invoices);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //30299985

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObjectList(invoices);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    public static void CompareSize_Of_Binary_To_JSON_1000000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());
        DataSource dataSource = new();
        var invoices = dataSource.GetComplexObjects(1000000);

        //---------------------- JSON ------------------//
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);
        Console.WriteLine($"    Json size in bytes: {serializedBytesJson.Length}");                     //742448246

        //---------------------- MessagePack ------------------//
        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), invoices);
        Console.WriteLine($"    MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //302999791

        //-----------------------Protobuf----------------------//
        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();
        Console.WriteLine($"    Protobuf size in bytes: {protoSerialized.Length}");                     //

        //-----------------------Avro----------------------//
        byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObjectList(invoices);
        Console.WriteLine($"    Avro size in bytes: {serializedBytesAvro.Length}");                     //
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string GetCurrentMethod()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        return sf.GetMethod().Name;
    }
}
