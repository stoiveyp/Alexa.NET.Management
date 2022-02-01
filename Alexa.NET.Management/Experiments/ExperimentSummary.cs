using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentSummary
    {
        [JsonProperty("experimentId")]
        public string ExperimentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentState State { get; set; }

        [JsonProperty("experimentHistory")]
        public ExperimentHistory History { get; set; }
    }
}