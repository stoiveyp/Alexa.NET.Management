using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillExecutionInfo
    {
        [JsonProperty("invocations",NullValueHandling = NullValueHandling.Ignore)]
        public Invocation[] Invocations { get; set; }
    }
}