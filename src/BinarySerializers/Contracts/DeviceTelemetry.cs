using MessagePack;
using ProtoBuf;

namespace BinarySerializers.Contracts;

[MessagePackObject]
[ProtoContract]
public class DeviceTelemetry
{
    [Key(0)]
    [ProtoMember(1)]
    public int Id { get; set; }

    [Key(1)]
    [ProtoMember(2)]
    public string Name { get; set; }

    [Key(2)]
    [ProtoMember(3)]
    public bool IsActive { get; set; }

    [Key(3)]
    [ProtoMember(4)]
    public float Temperature { get; set; }

    [Key(4)]
    [ProtoMember(5)]
    public double Pressure { get; set; }

    [Key(5)]
    [ProtoMember(6)]
    public DateTime Timestamp { get; set; }

    [Key(6)]
    [ProtoMember(7)]
    public List<string> Tags { get; set; }

    [Key(7)]
    [ProtoMember(8)]
    public Dictionary<string, int> SensorData { get; set; }
}
