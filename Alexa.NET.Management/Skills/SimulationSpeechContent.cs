using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SimulationSpeechContent
    {
        [JsonProperty("caption")]
        public string Caption { get; set; }
    }
}