using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SimulationRequestDevice
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
}