using PigTracks.Sensors.Enums;

namespace PigTracks.Sensors.Models;

public class SensorEvent
{
    public string? VendorId { get; set; }
    public string? DeviceId { get; set; }
    public DateTime EventDateTime { get; set; }
    public SensorEventType EventType { get; set; }
}
