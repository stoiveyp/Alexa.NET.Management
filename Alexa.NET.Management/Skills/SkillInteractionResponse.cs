using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillInteractionResponse
    {
        [JsonProperty("interactionModel")]
        public SkillInteraction InteractionModel { get; set; }
    }
}