using BinarySerializers.Contracts;
using BinarySerializers.DataContracts;
using BinarySerializers.Serializers;
using MessagePack;
using ProtoBuf;

namespace BinarySerializers.Benchmarking;

public class SerializationCompression
{
    private static readonly StreamWriter streamWriter;
    private static readonly int[] counts = [1, 10, 100, 1000, 10000, 100000, 1000000];

    static SerializationCompression()
    {
        string fileName = $"serialization_compression.md";
        streamWriter = new StreamWriter(fileName);
        streamWriter.WriteLine("| | | | | |");
        streamWriter.WriteLine("| -- | -- | -- | -- | -- |");
        streamWriter.WriteLine("| | JSON | MessagePack | Protobuf | Avro |");
    }

    public static void CompareSize_Of_Binary_To_JSON()
    {
        DataSource dataSource = new();

        streamWriter?.WriteLine("| Simple Object| | | | |");

        foreach (var count in counts)
        {
            if (count == 1)
            {
                var deviceTelemetries = dataSource.GetSimpleObjects(count);
                var deviceTelemetry = deviceTelemetries.First();

                var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(deviceTelemetries);

                var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(DeviceTelemetry), deviceTelemetry);

                byte[] protoSerialized;
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, deviceTelemetry);
                protoSerialized = stream.ToArray();

                byte[] serializedBytesAvro = AvroSerializer.SerializeSimpleObject(deviceTelemetry);

                streamWriter?.WriteLine($"| 1 | {serializedBytesJson.Length} | {serializedBytesMessagePack.Length} | {protoSerialized.Length} | {serializedBytesAvro.Length} |");
            }
            else
            {
                var deviceTelemetries = dataSource.GetSimpleObjects(count);

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

                streamWriter?.WriteLine($"| {count} | {serializedBytesJson.Length} | {serializedBytesMessagePack.Length} | {protoSerialized.Length} | {serializedBytesAvro.Length} |");
            }
        }

        streamWriter?.WriteLine("| Complex Object | | | | |");

        foreach (var count in counts)
        {
            if (count == 1)
            {
                var invoices = dataSource.GetComplexObjects(1);
                var invoice = invoices.FirstOrDefault();

                //---------------------- JSON ------------------//
                var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoice);

                //---------------------- MessagePack ------------------//
                var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(Invoice), invoice);

                //-----------------------Protobuf----------------------//
                byte[] protoSerialized;
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, invoice);
                protoSerialized = stream.ToArray();

                //-----------------------Avro----------------------//
                byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObject(invoice);

                streamWriter?.WriteLine($"| 1 | {serializedBytesJson.Length} | {serializedBytesMessagePack.Length} | {protoSerialized.Length} | {serializedBytesAvro.Length} |");
            }
            else
            {
                var invoices = dataSource.GetComplexObjects(count);

                //---------------------- JSON ------------------//
                var serializedBytesJson = JsonSerializer.SerializeToUtf8Bytes(invoices);

                //---------------------- MessagePack ------------------//
                var serializedBytesMessagePack = MessagePackSerializer.Serialize(typeof(List<Invoice>), invoices);

                //-----------------------Protobuf----------------------//
                byte[] protoSerialized;
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, invoices);
                protoSerialized = stream.ToArray();

                //-----------------------Avro----------------------//
                byte[] serializedBytesAvro = AvroSerializer.SerializeComplexObjectList(invoices);

                streamWriter?.WriteLine($"| {count} | {serializedBytesJson.Length} | {serializedBytesMessagePack.Length} | {protoSerialized.Length} | {serializedBytesAvro.Length} |");
            }
        }

        streamWriter?.Flush();
        streamWriter?.Close();
    }
}
