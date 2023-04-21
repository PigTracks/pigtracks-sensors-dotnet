using Microsoft.Extensions.DependencyInjection;
using PigTracks.Sensors.Configuration;

namespace PigTracks.Sensors.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPigTracksSensors(this IServiceCollection services,
        PigTracksSensorsConfiguration pigTracksSensorsConfiguration)
    {
        if (string.IsNullOrWhiteSpace(pigTracksSensorsConfiguration.PigTracksGraphQlEndpoint))
        {
            throw new Exception("PigTracks GraphQL Endpoint cannot be empty");
        }

        services.AddSingleton(pigTracksSensorsConfiguration);
        services.AddTransient<ISensorsClient, SensorsClient>();
        return services;
    }
}
