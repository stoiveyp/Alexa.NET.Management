using Alexa.NET.Response;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class InvocationSkillResponse
    {
        [JsonProperty("body")]
        public SkillResponse Response { get; set; }
    }
}