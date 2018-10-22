using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Package
{
    public class PackageUploadMetadata
    {
        [JsonProperty("uploadUrl")]
        public Uri UploadUri { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }
    }
}
