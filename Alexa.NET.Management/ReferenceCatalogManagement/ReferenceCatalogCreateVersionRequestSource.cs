using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogCreateVersionRequestSource
    {
        [JsonProperty("type")] public string Type => "URL";

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}