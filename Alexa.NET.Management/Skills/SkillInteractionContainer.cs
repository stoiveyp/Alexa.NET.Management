using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillInteractionContainer
    {
        [JsonProperty("interactionModel")]
        public SkillInteraction InteractionModel { get; set; }
    }
}