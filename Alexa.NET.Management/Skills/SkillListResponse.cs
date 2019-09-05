using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillListResponse
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("isTruncated")]
        public bool IsTruncated { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("skills")]
        public SkillSummary[] Skills { get; set; }
    }
}
