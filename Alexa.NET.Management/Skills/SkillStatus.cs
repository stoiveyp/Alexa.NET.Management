using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillStatus
    {
        [JsonProperty("manifest")]
        public StatusManifest Manifest { get; set; }
    }
}