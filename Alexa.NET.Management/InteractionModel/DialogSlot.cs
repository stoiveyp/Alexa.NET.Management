using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlot
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("elicitationRequired",NullValueHandling = NullValueHandling.Ignore)]
        public bool ElicitationRequired { get; set; }

        [JsonProperty("confirmationRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool ConfirmationRequired { get; set; }

        [JsonProperty("prompts", NullValueHandling = NullValueHandling.Ignore)]
        public DialogSlotPrompts Prompts { get; set; }

        [JsonProperty("validations", NullValueHandling = NullValueHandling.Ignore)]
        public DialogSlotValidation[] Validations { get; set; }
    }
}