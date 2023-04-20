using Microsoft.Extensions.Configuration;

namespace OpenTelemetry.Trace
{
    public interface ITracerSettings
    {
        void Configure(TracerProviderBuilder tracerBuilder, IConfigurationSection configSection);
    }
}
