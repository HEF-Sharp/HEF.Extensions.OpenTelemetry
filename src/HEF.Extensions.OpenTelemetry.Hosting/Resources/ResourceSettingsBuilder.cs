using Microsoft.Extensions.Configuration;
using System;

namespace OpenTelemetry.Resources
{
    public class ResourceSettingsBuilder
    {
        private readonly ResourceBuilder _resourceBuilder;

        private readonly IConfigurationSection _configSection;

        internal ResourceSettingsBuilder(ResourceBuilder resourceBuilder, IConfigurationSection configSection)
        {
            _resourceBuilder = resourceBuilder ?? throw new ArgumentNullException(nameof(resourceBuilder));

            _configSection = configSection ?? throw new ArgumentNullException(nameof(configSection));
        }

        public ResourceBuilder Settings(IResourceSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.Configure(_resourceBuilder, _configSection);

            return _resourceBuilder;
        }
    }
}
