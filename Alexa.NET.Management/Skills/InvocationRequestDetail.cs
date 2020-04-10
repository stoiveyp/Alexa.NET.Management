using Alexa.NET.Request;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class InvocationRequestDetail
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("body")]
        public SkillRequest Body { get; set; }
    }
}