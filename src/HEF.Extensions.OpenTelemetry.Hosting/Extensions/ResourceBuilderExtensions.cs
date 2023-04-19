using Microsoft.Extensions.Configuration;
using System;

namespace OpenTelemetry.Resources
{
    public static class ResourceBuilderExtensions
    {
        public const string DefaultSectionName = "Telemetry:Resource";

        public static ResourceSettingsBuilder ReadFrom(
            this ResourceBuilder resourceBuilder, IConfiguration configuration)
            => ReadFrom(resourceBuilder, configuration, DefaultSectionName);        

        public static ResourceSettingsBuilder ReadFrom(
            this ResourceBuilder resourceBuilder, IConfiguration configuration, string sectionName)
        {
            if (resourceBuilder == null)
                throw new ArgumentNullException(nameof(resourceBuilder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (string.IsNullOrWhiteSpace(sectionName))
                throw new ArgumentNullException(nameof(sectionName));

            return new ResourceSettingsBuilder(resourceBuilder, configuration.GetSection(sectionName));
        }
    }
}
