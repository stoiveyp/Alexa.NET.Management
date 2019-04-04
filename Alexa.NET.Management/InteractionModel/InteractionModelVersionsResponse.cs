using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class InteractionModelVersionsResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, InteractionModelVersionLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public string IsTruncated { get; set; }

        [JsonProperty("skillModelVersions")]
        public SkillModelVersionSummary[] SkillModelVersionsSummary { get; set; }
    }
}
