using System.Runtime.Serialization;

namespace PigTracks.Sensors.Enums;

public enum SensorEventType
{
    [EnumMember(Value = "POWERED_ON")]
    PoweredOn,
    [EnumMember(Value = "POWERED_OFF")]
    PoweredOff,
    [EnumMember(Value = "HEARTBEAT")]
    Heartbeat,
    [EnumMember(Value = "POTENTIAL_PASSAGE")]
    PotentialPassage,
    [EnumMember(Value = "STREAM_ON")]
    StreamOn,
    [EnumMember(Value = "STREAM_OFF")]
    StreamOff,
    [EnumMember(Value = "LOW_POWER_ON")]
    LowPowerOn,
    [EnumMember(Value = "LOW_POWER_OFF")]
    LowPowerOff,
    [EnumMember(Value = "WELD_COUNT_START")]
    WeldCountStart,
    [EnumMember(Value = "WELD_COUNT_END")]
    WeldCountEnd
}
