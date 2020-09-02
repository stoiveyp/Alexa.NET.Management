using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ListedReferenceCatalog:ReferenceCatalog
    {
        [JsonProperty("catalogId")]
        public string CatalogId { get; set; }

        [JsonProperty("_links",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,ApiLink> Links { get; set; }
    }
}