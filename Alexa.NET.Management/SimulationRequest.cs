using Alexa.NET.Management.Skills;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class SimulationRequest
    {
        [JsonProperty("input")]
        public SimulationRequestInput Input { get; set; }

        [JsonProperty("device")]
        private SimulationRequestDevice Device { get; set; }
    }
}