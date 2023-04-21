using PigTracks.Sensors.Enums;

namespace PigTracks.Sensors.Models;

public class Sensor
{
    public string? VendorId { get; set; }
    public string? DeviceId { get; set; }
    public SensorState? State { get; set; }
    public DateTime? LastHeartbeatDateTime { get; set; }
    public decimal? LastLatitude { get; set; }
    public decimal? LastLongitude { get; set; }
    public int? LastCellSignalStrength { get; set; }
    public int? LastSatelliteSignalStrength { get; set; }
    public int? LastBatteryStrength { get; set; }
    public int? Temperature { get; set; }
    public bool? IsAntennaOut { get; set; }
    public bool? IsGeophoneConnected { get; set; }
}
