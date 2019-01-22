using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.InteractionModel
{
    public class Dialog
    {
        [JsonProperty("intents")]
        public DialogIntent[] Intents { get; set; }

        [JsonProperty("delegationStrategy", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public IntentDelegationStrategy? DelegationStrategy { get; set; }
    }
}