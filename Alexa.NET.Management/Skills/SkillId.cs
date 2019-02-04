using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillId
    {
        [JsonProperty("skillId")]
        public string Id { get; set; }
    }
}
