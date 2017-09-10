using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class StatusManifest
    {
        [JsonProperty("lastModified")]
        public LastModifiedInformation LastModified { get; set; }
    }
}