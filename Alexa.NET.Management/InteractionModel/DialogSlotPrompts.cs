using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlotPrompts
    {
        [JsonProperty("elicitation", NullValueHandling = NullValueHandling.Ignore)]
        public string Elicitation { get; set; }

        [JsonProperty("confirmation", NullValueHandling = NullValueHandling.Ignore)]
        public string Confirmation { get; set; }
    }
}