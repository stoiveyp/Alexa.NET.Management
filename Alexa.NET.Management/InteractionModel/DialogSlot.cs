using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlot
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prompts")]
        public DialogSlotPrompts Prompts { get; set; }

        [JsonProperty("validations")]
        public DialogSlotValidation[] Validations { get; set; }
    }
}