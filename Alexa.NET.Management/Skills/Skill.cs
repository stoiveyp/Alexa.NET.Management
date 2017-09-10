using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class Skill
    {
        [JsonProperty("skillManifest")]
        public Manifest.SkillManifest Manifest { get; set; }
    }
}
