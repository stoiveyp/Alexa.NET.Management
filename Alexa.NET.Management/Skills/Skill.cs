using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class Skill
    {
        [JsonProperty("manifest")]
        public Manifest.SkillManifest Manifest { get; set; }
    }
}
