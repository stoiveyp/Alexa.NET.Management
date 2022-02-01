using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class SnapshotDataMetricValue
    {
        [JsonProperty("mean")]
        public double Mean { get; set; }

        [JsonProperty("percentDiff")]
        public double PercentDiff { get; set; }

        [JsonProperty("confidenceIntervalLower")]
        public double ConfidenceIntervalLower { get; set; }

        [JsonProperty("confidenceIntervalUpper")]
        public double ConfidenceIntervalUpper { get; set; }

        [JsonProperty("pValue")]
        public double PValue { get; set; }

        [JsonProperty("userCount")]
        public long UserCount { get; set; }
    }
}