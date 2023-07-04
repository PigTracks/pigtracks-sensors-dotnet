using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using PigTracks.Sensors.Configuration;
using PigTracks.Sensors.Models;

namespace PigTracks.Sensors;

public interface ISensorsClient
{
    Task UpdateSensor(Sensor sensor);
    Task AddSensorData(string vendorId, string deviceId, IList<SensorDataPoint> sensorDataPoints);
}

public class SensorsClient : ISensorsClient
{
    private readonly IGraphQLClient _graphQlClient;

    public SensorsClient(PigTracksSensorsConfiguration pigTracksSensorsConfiguration)
    {
        if (pigTracksSensorsConfiguration == null)
        {
            throw new ArgumentException("PigTracksSensorsConfiguration can not be null");
        }

        if (string.IsNullOrWhiteSpace(pigTracksSensorsConfiguration.PigTracksGraphQlEndpoint))
        {
            throw new Exception("PigTracks GraphQL Endpoint cannot be null or empty");
        }

        _graphQlClient = new GraphQLHttpClient(pigTracksSensorsConfiguration.PigTracksGraphQlEndpoint,
            new SystemTextJsonSerializer());
    }

    public async Task UpdateSensor(Sensor sensor)
    {
        if (string.IsNullOrWhiteSpace(sensor.VendorId) || string.IsNullOrWhiteSpace(sensor.DeviceId))
        {
            throw new Exception("VendorId and DeviceId are required");
        }

        var updateSensorGraphQlRequest = new GraphQLRequest
        {
            Query = @"
                mutation UpdateSensor($input: UpdateSensorInput!) {
                    sensors {
                        update(input: $input) {
                            message
                        }
                    }
                }
            ",
            OperationName = "UpdateSensor",
            Variables = new
            {
                input = sensor
            }
        };
        await _graphQlClient.SendMutationAsync<object>(updateSensorGraphQlRequest);
    }

    public async Task AddSensorData(string vendorId, string deviceId, IList<SensorDataPoint> sensorDataPoints)
    {
        var addSensorDataGraphQlRequest = new GraphQLRequest
        {
            Query = @"
                mutation AddSensorData($input: AddSensorDataInput) {
                    sensors {
                        addData(input: $input) {
                            message
                        }
                    }
                }
            ",
            OperationName = "AddSensorData",
            Variables = new
            {
                input = new
                {
                    vendorId,
                    deviceId,
                    sensorDataPoints
                }
            }
        };
        await _graphQlClient.SendMutationAsync<object>(addSensorDataGraphQlRequest);
    }

    public async Task AddSensorEvent(string vendorId, string deviceId, SensorEvent sensorEvent)
    {
        var addSensorEventGraphQlRequest = new GraphQLRequest
        {
            Query = @"
                mutation AddSensorEvent($input: AddSensorEventInput!) {
                    sensors {
                        addEvent(input: $input) {
                            message
                        }
                    }
                }
            ",
            OperationName = "AddSensorEvent",
            Variables = new
            {
                input = new
                {
                    vendorId,
                    deviceId,
                    sensorEvent
                }
            }
        };
        await _graphQlClient.SendMutationAsync<object>(addSensorEventGraphQlRequest);
    }
}