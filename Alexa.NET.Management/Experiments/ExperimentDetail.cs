using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentDetail : Experiment
    {
        [JsonProperty("history")]
        public ExperimentHistory History { get; set; }

        [JsonProperty("trigger")]
        public ExperimentTrigger Trigger { get; set; }

        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentState State { get; set; }
    }
}