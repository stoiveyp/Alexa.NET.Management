using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlotPrompts
    {
        [JsonProperty("elicitation")]
        public string Elicitation { get; set; }

        [JsonProperty("confirmation")]
        public string Confirmation { get; set; }
    }
}