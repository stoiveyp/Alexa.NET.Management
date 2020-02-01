using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SkillDevelopmentActor
    {
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }
    }
}