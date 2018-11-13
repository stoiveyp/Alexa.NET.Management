using Alexa.NET.Management.InteractionModel;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillInteraction
    {
        [JsonProperty("languageModel")]
        public Language Language { get; set; }

        [JsonProperty("dialog")]
        public Dialog Dialog { get; set; }

        [JsonProperty("prompts")]
        public Prompt[] Prompts { get; set; }
    }
}
