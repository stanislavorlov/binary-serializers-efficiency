using Avro;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using Avro.IO;
using BinarySerializers.Contracts;
using BinarySerializers.DataContracts;
using BinarySerializers.Serializers;

namespace BinarySerializers.Serializers;

public class AvroSerializer<T>
{
    private static Schema deviceTelemetrySchema;

    static AvroSerializer()
    {
        // Initialize the Avro serializer settings if needed

        deviceTelemetrySchema = Schema.Parse(@"
            {
                ""type"": ""record"",
                ""name"": ""DeviceTelemetry"",
                ""fields"": [
                    {""name"": ""Id"", ""type"": ""int""},
                    {""name"": ""Name"", ""type"": ""string""},
                    {""name"": ""IsActive"", ""type"": ""boolean""},
                    {""name"": ""Temperature"", ""type"": ""float""},
                    {""name"": ""Pressure"", ""type"": ""double""},
                    {""name"": ""Timestamp"", ""type"": ""long"" },
                    {""name"": ""Tags"", ""type"": {""type"": ""array"", ""items"": ""string""}},
                    {""name"": ""SensorData"", ""type"": {""type"": ""map"", ""values"": ""int""}}
                ]
            }");
    }

    public static byte[] SerializeSimpleObject(DeviceTelemetry instance)
    {
        var totalTicks = instance.Timestamp.ToUniversalTime().Ticks / TimeSpan.TicksPerMillisecond;
        var avroSensorData = instance.SensorData.ToDictionary(kv => kv.Key, kv => (object)kv.Value);

        var record = new GenericRecord((RecordSchema)deviceTelemetrySchema);
        record.Add("Id", instance.Id);
        record.Add("Name", instance.Name);
        record.Add("IsActive", instance.IsActive);
        record.Add("Temperature", instance.Temperature);
        record.Add("Pressure", instance.Pressure);
        record.Add("Timestamp", totalTicks);
        record.Add("Tags", instance.Tags.ToArray());
        record.Add("SensorData", avroSensorData);

        using var memoryStream = new MemoryStream();
        var writer = new BinaryEncoder(memoryStream);
        var datumWriter = new GenericWriter<GenericRecord>(deviceTelemetrySchema);
        datumWriter.Write(record, writer);
        writer.Flush();

        return memoryStream.ToArray();
    }

    public static DeviceTelemetry DeserializeSimpleObject(byte[] buffer)
    {
        using var ms = new MemoryStream(buffer);
        var reader = new BinaryDecoder(ms);
        var datumReader = new GenericReader<GenericRecord>(deviceTelemetrySchema, deviceTelemetrySchema);
        var deserializedRecord = datumReader.Read((GenericRecord?)null, reader);

        var tags = (IList<object>)deserializedRecord["Tags"];
        var sensorData = (IDictionary<string, object>)deserializedRecord["SensorData"];

        var telemetry = new DeviceTelemetry
        {
            Id = (int)deserializedRecord["Id"],
            Name = (string)deserializedRecord["Name"],
            IsActive = (bool)deserializedRecord["IsActive"],
            Temperature = (float)deserializedRecord["Temperature"],
            Pressure = (double)deserializedRecord["Pressure"],
            Timestamp = DateTimeOffset.FromUnixTimeMilliseconds((long)deserializedRecord["Timestamp"]).UtcDateTime,
            Tags = [.. tags.Cast<string>()],
            SensorData = sensorData.ToDictionary(kv => kv.Key, kv => (int)kv.Value)
        };

        return telemetry;
    }
}
