using Alexa.NET.Management.Skills;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class InvocationRequest
    {
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        [JsonProperty("skillRequest")]
        public InvocationSkillRequest Request { get; set; }
    }
}