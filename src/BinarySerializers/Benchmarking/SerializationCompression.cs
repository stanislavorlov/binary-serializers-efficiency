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
    public static void CompareSize_Of_MessagePack_To_JSON_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(DeviceTelemetry), deviceTelemetries.First());
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //84
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //230
    }

    public static void CompareSize_Of_MessagePack_To_JSON_1000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //84003
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //228304
    }

    public static void CompareSize_Of_MessagePack_To_JSON_10000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(10000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //840003
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //2282627
    }

    public static void CompareSize_Of_MessagePack_To_JSON_100000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(100000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //8400003
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //22827104
    }

    public static void CompareSize_Of_MessagePack_To_JSON_1000000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<DeviceTelemetry>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //83999941
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //228270604
    }

    public static void CompareSize_Of_MessagePack_To_JSON_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetComplexObjects(1);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(Invoice), deviceTelemetries.First());
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //303
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //744
    }

    public static void CompareSize_Of_MessagePack_To_JSON_1000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetComplexObjects(1000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //303003
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //742419
    }

    public static void CompareSize_Of_MessagePack_To_JSON_10000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetComplexObjects(10000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //3029999
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //7424503
    }

    public static void CompareSize_Of_MessagePack_To_JSON_100000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetComplexObjects(100000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //30299985
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //74244775
    }

    public static void CompareSize_Of_MessagePack_To_JSON_1000000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetComplexObjects(1000000);

        var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), deviceTelemetries);
        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"MessagePack size in bytes: {serializedBytesMessagePack.Length}");       //302999791
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //742448246
    }

    public static void CompareSize_Of_Protobuf_To_JSON_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries.First());
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //98
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //229
    }

    public static void CompareSize_Of_Protobuf_To_JSON_1000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //99871
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //228323
    }

    public static void CompareSize_Of_Protobuf_To_JSON_10000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(10000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //998742
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //2282684
    }

    public static void CompareSize_Of_Protobuf_To_JSON_100000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(100000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //99874447
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //228268926
    }

    public static void CompareSize_Of_Protobuf_To_JSON_1000000_SimpleObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var deviceTelemetries = dataSource.GetSimpleObjects(1000000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, deviceTelemetries);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //
    }

    public static void CompareSize_Of_Protobuf_To_JSON_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var invoices = dataSource.GetComplexObjects(1);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //335
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //742
    }

    public static void CompareSize_Of_Protobuf_To_JSON_1000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var invoices = dataSource.GetComplexObjects(1000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //
    }

    public static void CompareSize_Of_Protobuf_To_JSON_10000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var invoices = dataSource.GetComplexObjects(10000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //
    }

    public static void CompareSize_Of_Protobuf_To_JSON_100000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var invoices = dataSource.GetComplexObjects(100000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //
    }

    public static void CompareSize_Of_Protobuf_To_JSON_1000000_ComplexObject()
    {
        Console.WriteLine(GetCurrentMethod());

        DataSource dataSource = new DataSource();

        var invoices = dataSource.GetComplexObjects(1000000);

        byte[] protoSerialized;
        using var stream = new MemoryStream();
        Serializer.Serialize(stream, invoices);
        protoSerialized = stream.ToArray();

        var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

        Console.WriteLine($"Protobuf size in bytes: {protoSerialized.Length}");                     //
        Console.WriteLine($"Json size in bytes: {serializedBytesJson.Length}");                     //
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string GetCurrentMethod()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(1);

        return sf.GetMethod().Name;
    }
}
