using System;

namespace OpenTelemetry.Trace
{
    public static class OtlpTraceExporterExtensions
    {
        public static TracerProviderBuilder AddOtlpExporter(this TracerProviderSettingsBuilder settingBuilder)
        {
            if (settingBuilder == null)
                throw new ArgumentNullException(nameof(settingBuilder));

            return settingBuilder.Settings(new TracerOtlpExporterConfigurationReader());
        }
    }
}
