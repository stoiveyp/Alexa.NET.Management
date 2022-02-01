using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class Experiment:ExperimentBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentType Type { get; set; }
    }
}