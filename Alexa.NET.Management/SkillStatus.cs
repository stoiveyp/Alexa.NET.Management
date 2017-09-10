using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class SkillStatus
    {
        [JsonProperty("manifest")]
        public StatusManifest Manifest { get; set; }
    }
}