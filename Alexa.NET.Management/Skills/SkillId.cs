using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillId
    {
        [JsonProperty("skill_id")]
        public string Id { get; set; }
    }
}
