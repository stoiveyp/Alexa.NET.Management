using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class Skill
    {
        [JsonProperty("skillManifest")]
        public SkillManifest Manifest { get; set; }
    }
}
