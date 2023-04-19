using Microsoft.Extensions.Configuration;

namespace OpenTelemetry.Resources
{
    public interface IResourceSettings
    {
        void Configure(ResourceBuilder resourceBuilder, IConfigurationSection configSection);
    }
}
