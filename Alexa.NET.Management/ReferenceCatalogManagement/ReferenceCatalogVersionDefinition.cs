using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogVersionDefinition
    {
        [JsonProperty("source")]
        public ReferenceCatalogSource Catalog { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}