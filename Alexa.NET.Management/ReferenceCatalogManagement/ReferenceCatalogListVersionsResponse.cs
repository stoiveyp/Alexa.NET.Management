using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogListVersionsResponse
    {
        [JsonProperty("isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTruncated { get; set; }

        [JsonProperty("catalogVersions")]
        public ListedReferenceCatalogVersion[] CatalogVersions { get; set; }

        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalCount { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}