using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Api
{
    public class CustomApiEndpoint
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("sslCertificateType")]
        public SslCertificateType SslCertificateType { get; set; }
    }
}
