using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class MetricSnapshotData
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MetricSnapshotDataStatus Status { get; set; }

        [JsonProperty("statusReason")]
        public string StatusReason { get; set; }

        [JsonProperty("metrics",NullValueHandling = NullValueHandling.Ignore)]
        public SnapshotDataMetric[] Metrics { get; set; }
    }
}