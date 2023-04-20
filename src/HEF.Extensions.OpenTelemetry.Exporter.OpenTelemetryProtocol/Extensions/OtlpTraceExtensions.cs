using Microsoft.Extensions.Configuration;
using System;

namespace OpenTelemetry.Trace
{
    public static class OtlpTraceExtensions
    {
        public const string DefaultSectionName = "Telemetry:Tracer";

        public static TracerProviderSettingsBuilder ReadFrom(
            this TracerProviderBuilder tracerBuilder, IConfiguration configuration)
            => ReadFrom(tracerBuilder, configuration, DefaultSectionName);

        public static TracerProviderSettingsBuilder ReadFrom(
            this TracerProviderBuilder tracerBuilder, IConfiguration configuration, string sectionName)
        {
            if (tracerBuilder == null)
                throw new ArgumentNullException(nameof(tracerBuilder));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (string.IsNullOrWhiteSpace(sectionName))
                throw new ArgumentNullException(nameof(sectionName));

            return new TracerProviderSettingsBuilder(tracerBuilder, configuration.GetSection(sectionName));
        }
    }
}
