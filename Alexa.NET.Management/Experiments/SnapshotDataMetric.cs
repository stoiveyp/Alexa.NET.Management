using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class SnapshotDataMetric
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("treatmentId")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TreatmentId TreatmentId { get; set; }

        [JsonProperty("values")]
        public SnapshotDataMetricValue Values { get; set; }
    }
}