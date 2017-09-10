using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogSlotValidation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }
    }
}