using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ListedReferenceCatalogVersion : ReferenceCatalogVersionBase
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}