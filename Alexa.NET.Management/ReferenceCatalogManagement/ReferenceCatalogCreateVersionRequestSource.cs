using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogSource
    {
        [JsonProperty("type")] 
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}