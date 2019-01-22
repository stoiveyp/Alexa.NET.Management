using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogIntent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("delegationStrategy", NullValueHandling = NullValueHandling.Ignore),JsonConverter(typeof(StringEnumConverter))]
        public IntentDelegationStrategy? DelegationStrategy { get; set; }

        [JsonProperty("confirmationRequired", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ConfirmationRequired { get; set; }

        [JsonProperty("slots", NullValueHandling = NullValueHandling.Ignore)]
        public DialogSlot[] Slots { get; set; }

        [JsonProperty("prompts", NullValueHandling = NullValueHandling.Ignore)]
        public IntentPrompt Prompts { get; set; }
    }
}