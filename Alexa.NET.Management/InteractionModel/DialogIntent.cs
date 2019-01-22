using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogIntent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("confirmationRequired")]
        public bool ConfirmationRequired { get; set; }

        [JsonProperty("slots")]
        public DialogSlot[] Slots { get; set; }

        [JsonProperty("prompts", NullValueHandling = NullValueHandling.Ignore)]
        public IntentPrompt Prompts { get; set; }
    }
}