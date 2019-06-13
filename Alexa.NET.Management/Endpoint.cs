using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management
{
    public class Endpoint
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("sslCertificateType", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public SslCertificateType? SslCertificateType { get; set; }
    }
}