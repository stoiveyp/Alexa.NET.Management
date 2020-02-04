using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class InteractionModelPayload:SkillDevelopmentEventPayload
    {
        [JsonProperty("interactionModel")]
        public InteractionModelDetail InteractionModel { get; set; }
    }
}