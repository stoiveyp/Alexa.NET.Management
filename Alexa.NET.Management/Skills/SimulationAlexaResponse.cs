using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    [JsonConverter(typeof(SimulationResponseConverter))]
    public abstract class SimulationAlexaResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public abstract class SimulationAlexaResponse<T>:SimulationAlexaResponse
    {
        [JsonProperty("content")]
        public T Content { get; set; }
    }
}