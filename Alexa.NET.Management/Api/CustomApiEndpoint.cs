using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Api
{
    public class CustomApiEndpoint
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("sslCertificateType"), JsonConverter(typeof(StringEnumConverter))]
        public SslCertificateType SslCertificateType { get; set; }
    }
}
