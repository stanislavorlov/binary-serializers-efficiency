using MessagePack;
using ProtoBuf;

namespace BinarySerializers.Contracts;

[MessagePackObject]
[ProtoContract]
public class DeviceTelemetry
{
    [Key(0)]
    [ProtoMember(1)]
    public required int Id { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public required string Name { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public required bool IsActive { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public required float Temperature { get; set; }

    [Key(4)]
    [ProtoMember(5)]
    public required double Pressure { get; set; }

    [Key(5)]
    [ProtoMember(6)]
    public required DateTime Timestamp { get; set; }

    [Key(6)]
    [ProtoMember(7)]
    public required List<string> Tags { get; set; }

    [Key(7)]
    [ProtoMember(8)]
    public required Dictionary<string, int> SensorData { get; set; }
}
