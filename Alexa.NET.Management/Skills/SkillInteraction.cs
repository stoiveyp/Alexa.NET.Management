using Alexa.NET.Management.InteractionModel;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillInteraction
    {
        [JsonProperty("languageModel")]
        public Language Language { get; set; }

        [JsonProperty("dialog",NullValueHandling = NullValueHandling.Ignore)]
        public Dialog Dialog { get; set; }

        [JsonProperty("prompts", NullValueHandling = NullValueHandling.Ignore)]
        public Prompt[] Prompts { get; set; }
    }
}
