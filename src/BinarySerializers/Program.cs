// See https://aka.ms/new-console-template for more information
using BinarySerializers;
using BinarySerializers.Contracts;
using MessagePack;
using Newtonsoft.Json;
using ProtoBuf;
using System.Text;

var telemetry = new DeviceTelemetry
{
    Id = 101,
    Name = "Sensor-X9",
    IsActive = true,
    Temperature = 36.5f,
    Pressure = 1013.25,
    Timestamp = new DateTime(2025, 7, 1, 15, 30, 0, DateTimeKind.Utc),
    Tags = new List<string> { "env", "critical", "zone-1" },
    SensorData = new Dictionary<string, int>
    {
        ["humidity"] = 45,
        ["vibration"] = 7
    }
};

JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
jsonSerializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
jsonSerializerSettings.ContractResolver = new PrivateContractResolver();
JsonSerializer _jsonSerializer = JsonSerializer.Create(jsonSerializerSettings);

using StringWriter stringWriter = new();
_jsonSerializer.Serialize(stringWriter, telemetry);

var jsonSerialized = Encoding.UTF8.GetBytes(stringWriter.GetStringBuilder().ToString());
Console.WriteLine("JSON serialization in bytes:");
Console.WriteLine(BitConverter.ToString(jsonSerialized));

var messagePackSerialized = MessagePackSerializer.Serialize(telemetry.GetType(), telemetry);
Console.WriteLine($"MessagePack serialization in bytes");
Console.WriteLine(BitConverter.ToString(messagePackSerialized));

byte[] protoSerialized;
using (var stream = new MemoryStream())
{
    Serializer.Serialize(stream, telemetry);
    protoSerialized = stream.ToArray();
}

Console.WriteLine($"ProtoBuf serialization in bytes");
Console.WriteLine(BitConverter.ToString(protoSerialized));