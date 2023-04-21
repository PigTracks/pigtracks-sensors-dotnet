using System.Runtime.Serialization;

namespace PigTracks.Sensors.Enums;

public enum SensorType
{
    [EnumMember(Value = "MAGNET")]
    Magnet,
    [EnumMember(Value = "EXTREMELY_LOW_FREQUENCY")]
    ExtremelyLowFrequency,
    [EnumMember(Value = "GEOPHONE")]
    Geophone
}
