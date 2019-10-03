using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class ProductListResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("inSkillProducts")]
        public ProductSummary[] InSkillProducts { get; set; }
    }
}
