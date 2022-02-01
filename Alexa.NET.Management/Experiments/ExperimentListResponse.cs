using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentListResponse
    {
        [JsonProperty("experiments",NullValueHandling = NullValueHandling.Ignore)]
        public ExperimentSummary[] Experiments { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTruncated { get; set; }
    }
}