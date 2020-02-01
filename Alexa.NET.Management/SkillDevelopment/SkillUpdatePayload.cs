using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SkillUpdatePayload : SkillDevelopmentEventPayload
    {
        [JsonProperty("skill")]
        public SkillDetail Skill { get; set; }
    }
}