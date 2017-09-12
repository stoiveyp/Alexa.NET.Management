using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillExecutionInfo
    {
        [JsonProperty("invocationRequest")]
        public InvocationRequest Request { get; set; }

        [JsonProperty("invocationResponse")]
        public InvocationSkillResponse Response { get; set; }

        [JsonProperty("metrics")]
        public InvocationMetrics Metrics { get; set; }
    }
}