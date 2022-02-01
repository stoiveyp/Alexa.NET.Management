using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class MetricSnapshotResponse
    {
        [JsonProperty("metricSnapshots",NullValueHandling = NullValueHandling.Ignore)]
        public MetricSnapshot[] MetricSnapshots { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTruncated { get; set; }
    }
}