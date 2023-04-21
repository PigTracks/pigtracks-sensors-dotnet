using PigTracks.Sensors.Enums;

namespace PigTracks.Sensors.Models;

public class SensorDataPoint
{
    public DateTime DataDateTime { get; set; }
    public SensorType SensorType { get; set; }
    public int Value { get; set; }
}
