using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.InSkillProduct;
using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class CatalogListResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("catalogs")]
        public Catalog[] Catalogs { get; set; }
    }
}
