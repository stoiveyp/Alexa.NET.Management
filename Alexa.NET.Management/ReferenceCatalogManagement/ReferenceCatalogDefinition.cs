using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogDefinition
    {
        [JsonProperty("catalog")]
        public ReferenceCatalog Catalog { get; set; }

        [JsonProperty("createTime",NullValueHandling = NullValueHandling.Ignore)]
        public string CreateTime { get; set; }

        [JsonProperty("totalVersions",NullValueHandling = NullValueHandling.Ignore)]
        public int TotalVersions { get; set; }
    }
}