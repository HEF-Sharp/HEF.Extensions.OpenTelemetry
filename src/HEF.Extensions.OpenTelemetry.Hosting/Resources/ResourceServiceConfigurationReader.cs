using Microsoft.Extensions.Configuration;

namespace OpenTelemetry.Resources
{
    public class ResourceServiceConfigurationReader : IResourceSettings
    {
        internal ResourceServiceConfigurationReader()
        { }

        public void Configure(ResourceBuilder resourceBuilder, IConfigurationSection configSection)
        {
            var serviceName = configSection.GetValue<string>("serviceName");
            var serviceNamespace = configSection.GetValue<string>("serviceNamespace");
            var serviceVersion = configSection.GetValue<string>("serviceVersion");
            var serviceInstanceId = configSection.GetValue<string>("serviceInstanceId");

            resourceBuilder.AddService(serviceName, serviceNamespace: serviceNamespace,
                serviceVersion: serviceVersion, serviceInstanceId: serviceInstanceId);
        }
    }
}
