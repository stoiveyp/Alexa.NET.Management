using Alexa.NET.Request;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class InvocationSkillRequest
    {
        [JsonProperty("body")]
        public SkillRequest Body { get; set; }
    }
}