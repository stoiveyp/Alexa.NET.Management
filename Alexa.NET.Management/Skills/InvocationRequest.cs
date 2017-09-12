using Alexa.NET.Management.Skills;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class InvocationRequest
    {
        [JsonProperty("endpointRegion")]
        public string EndpointRegion { get; set; }

        [JsonProperty("skillRequest")]
        public InvocationSkillRequest Request { get; set; }
    }
}