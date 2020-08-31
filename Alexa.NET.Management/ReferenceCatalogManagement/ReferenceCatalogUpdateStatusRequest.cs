using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogUpdateStatusRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("error",NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceCatalogUpdateStatusError[] Error { get; set; }
    }
}