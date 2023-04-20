using Microsoft.Extensions.Configuration;
using System;

namespace OpenTelemetry.Trace
{
    public class TracerProviderSettingsBuilder
    {
        private readonly TracerProviderBuilder _tracerBuilder;

        private readonly IConfigurationSection _configSection;

        internal TracerProviderSettingsBuilder(TracerProviderBuilder tracerBuilder, IConfigurationSection configSection)
        {
            _tracerBuilder = tracerBuilder ?? throw new ArgumentNullException(nameof(tracerBuilder));

            _configSection = configSection ?? throw new ArgumentNullException(nameof(configSection));
        }

        public TracerProviderBuilder Settings(ITracerSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            settings.Configure(_tracerBuilder, _configSection);

            return _tracerBuilder;
        }
    }
}
