using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentRequestHistory
{
    public class IntentRequestHistoryResponseBody
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("totalCount")]
        public string TotalCount { get; set; }

        [JsonProperty("skillId")]
        public string SkillId { get; set; }

        [JsonProperty("startIndex")]
        public string StartIndex { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("items")]
        public IntentRequestHistoryItem[] Items { get; set; }
    }
}
