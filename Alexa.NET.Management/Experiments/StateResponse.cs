using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class StateResponse
    {
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentState State { get; set; }
    }
}