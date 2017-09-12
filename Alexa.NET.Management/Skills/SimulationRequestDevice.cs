using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    internal class SimulationRequestDevice
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }
    }
}