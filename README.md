# PigTracks Sensors .NET Client

## Usage

Register the PigTracks Sensor Client with your services:

```
services.AddPigTracksSensors(new PigTracksSensorsConfiguration
{
    PigTracksGraphQlEndpoint = "https://api.pigtracks.co/graphql"
});
```

Inject in the ISensorClient:

```
private readonly ISensorsClient _sensorsClient;

public MyClass(ISensorsClient sensorsClient)
{
    _sensorsClient = sensorsClient;
}
```

Make a call to PigTracks Sensors:

```
await _sensorsClient.UpdateSensor(new Sensor
{
    VendorId = vendorId,
    DeviceId = deviceId,
    LastHeartbeatDateTime = mostRecentHeartbeat.HeartbeatTimeStamp.AsUtc(),
    LastLatitude = mostRecentHeartbeat.Lat.ToDecimalWhereZeroIsNull(),
    LastLongitude = mostRecentHeartbeat.Lon.ToDecimalWhereZeroIsNull(),
    LastBatteryStrength = mostRecentHeartbeat.Battery,
    LastSatelliteSignalStrength = mostRecentHeartbeat.IsIridium.HasValue && mostRecentHeartbeat.IsIridium.Value ? mostRecentHeartbeat.SignalStrength : null,
    LastCellSignalStrength = !mostRecentHeartbeat.IsIridium.HasValue || !mostRecentHeartbeat.IsIridium.Value ? mostRecentHeartbeat.SignalStrength : null,
    Temperature = mostRecentHeartbeat.Temperature,
    IsGeophoneConnected = mostRecentHeartbeat.GeophoneConnected,
});
```

Here is another example:

```
await _sensorsClient.AddSensorData(vendorId, deviceId, sensorDataPoints.OrderBy(x => x.DataDateTime).ToList());
```
