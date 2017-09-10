using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Api
{
    public class CustomApiRegionEndpoint
    {
        [JsonProperty("sslCertificateType"), JsonConverter(typeof(StringEnumConverter))]
        public SslCertificateType SslCertificateType { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}