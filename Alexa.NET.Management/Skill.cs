using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class Skill
    {
        [JsonProperty("skillManifest")]
        public Manifest.SkillManifest Manifest { get; set; }
    }
}
