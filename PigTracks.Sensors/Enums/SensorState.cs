using System.Runtime.Serialization;

namespace PigTracks.Sensors.Enums;

public enum SensorState
{
    [EnumMember(Value = "SLEEP")]
    Sleep,
    [EnumMember(Value = "ACTIVE")]
    Active,
    [EnumMember(Value = "STREAM")]
    Stream
}
