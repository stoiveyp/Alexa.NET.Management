using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class StatusManifest
    {
        [JsonProperty("lastModified")]
        public LastModifiedInformation LastModified { get; set; }
    }
}