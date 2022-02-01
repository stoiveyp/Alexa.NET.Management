using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    internal class UpdateStateRequest
    {
        [JsonProperty("targetState")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentUpdateState TargetState { get; set; }
    }
}