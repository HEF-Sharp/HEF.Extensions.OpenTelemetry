using System;

namespace OpenTelemetry.Resources
{
    public static class ResourceBuilderServiceExtensions
    {
        public static ResourceBuilder AddService(this ResourceSettingsBuilder settingBuilder)
        {
            if (settingBuilder == null)
                throw new ArgumentNullException(nameof(settingBuilder));

            return settingBuilder.Settings(new ResourceServiceConfigurationReader());
        }
    }
}
