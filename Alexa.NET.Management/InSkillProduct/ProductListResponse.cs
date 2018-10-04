using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class ProductListResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, InProductLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public string IsTruncated { get; set; }

        [JsonProperty("inSkillProducts")]
        public ProductSummary[] InSkillProducts { get; set; }
    }
}
