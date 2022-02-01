using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentListResponse
    {
        [JsonProperty("experiments",NullValueHandling = NullValueHandling.Ignore)]
        public ExperimentSummary[] Experiments { get; set; }
    }
}