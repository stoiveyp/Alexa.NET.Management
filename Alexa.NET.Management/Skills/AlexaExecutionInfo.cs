using Alexa.NET.Request;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class AlexaExecutionInfo
    {
        [JsonProperty("alexaResponses")]
        public SimulationAlexaResponse[] AlexaResponses { get; set; }

        [JsonProperty("consideredIntents",NullValueHandling = NullValueHandling.Ignore)]
        public Intent[] ConsideredIntents { get; set; }
    }
}