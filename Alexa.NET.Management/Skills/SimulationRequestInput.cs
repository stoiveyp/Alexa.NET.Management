using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SimulationRequestInput
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}