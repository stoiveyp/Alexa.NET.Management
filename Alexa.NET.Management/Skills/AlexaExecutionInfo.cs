using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class AlexaExecutionInfo
    {
        [JsonProperty("alexaResponses")]
        public SimulationAlexaResponse[] AlexaResponses { get; set; }
    }
}