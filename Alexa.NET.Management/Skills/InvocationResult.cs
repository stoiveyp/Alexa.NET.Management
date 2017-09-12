using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class InvocationResult
    {
        [JsonProperty("skillExecutionInfo")]
        public SkillExecutionInfo SkillExecutionInfo { get; set; }

        [JsonProperty("error")]
        public InvocationError Error { get; set; }
    }
}