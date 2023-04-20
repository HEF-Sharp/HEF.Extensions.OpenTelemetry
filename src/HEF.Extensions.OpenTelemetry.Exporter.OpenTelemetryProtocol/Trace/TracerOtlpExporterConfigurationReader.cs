using Microsoft.Extensions.Configuration;
using OpenTelemetry.Exporter;
using System;
using System.Globalization;

namespace OpenTelemetry.Trace
{
    public class TracerOtlpExporterConfigurationReader : ITracerSettings
    {
        internal TracerOtlpExporterConfigurationReader()
        { }

        public void Configure(TracerProviderBuilder tracerBuilder, IConfigurationSection configSection)
        {
            var otlpConfigSection = configSection.GetSection("Exporter:Otlp");
            var otlpExporterConfigure = BuildOtlpExporterOptionsConfigure(otlpConfigSection);

            tracerBuilder.AddOtlpExporter(otlpExporterConfigure);
        }

        protected static Action<OtlpExporterOptions> BuildOtlpExporterOptionsConfigure(IConfigurationSection otlpConfigSection)
        {
            var endpointStr = otlpConfigSection.GetValue<string>("Endpoint");
            var headersStr = otlpConfigSection.GetValue<string>("Headers");
            var timeoutStr = otlpConfigSection.GetValue<string>("Timeout");
            var protocolStr = otlpConfigSection.GetValue<string>("Protocol");

            return options =>
            {
                if (TryParseUri(endpointStr, out Uri endpoint))
                {
                    options.Endpoint = endpoint;
                }

                if (!string.IsNullOrWhiteSpace(headersStr))
                {
                    options.Headers = headersStr;
                }

                if (TryParseInt(timeoutStr, out int timeout))
                {
                    options.TimeoutMilliseconds = timeout;
                }

                if (TryParseProtocol(protocolStr, out OtlpExportProtocol protocol))
                {
                    options.Protocol = protocol;
                }
            };
        }

        #region Helper Functions
        private static bool TryParseUri(string uriStr, out Uri uriValue)
        {
            uriValue = null;

            if (string.IsNullOrWhiteSpace(uriStr))
                return false;

            return Uri.TryCreate(uriStr, UriKind.Absolute, out uriValue);
        }

        private static bool TryParseInt(string intStr, out int intValue)
        {
            intValue = default;

            if (string.IsNullOrWhiteSpace(intStr))
                return false;

            return int.TryParse(intStr, NumberStyles.None, CultureInfo.InvariantCulture, out intValue);
        }

        private static bool TryParseProtocol(string protocolStr, out OtlpExportProtocol protocolValue)
        {
            protocolValue = default;

            if (string.IsNullOrWhiteSpace(protocolStr))
                return false;

            switch (protocolStr.Trim())
            {
                case "grpc":
                    protocolValue = OtlpExportProtocol.Grpc;
                    return true;
                case "http/protobuf":
                    protocolValue = OtlpExportProtocol.HttpProtobuf;
                    return true;
                default:
                    protocolValue = default;
                    return false;
            }
        }
        #endregion
    }
}
