using Alexa.NET.Management.Skills;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class SimulationRequest
    {
        [JsonProperty("session",NullValueHandling = NullValueHandling.Ignore)]
        public SimulationSession Session { get; set; }

        [JsonProperty("input")]
        public SimulationRequestInput Input { get; set; }

        [JsonProperty("device")]
        private SimulationRequestDevice Device { get; set; }
    }
}