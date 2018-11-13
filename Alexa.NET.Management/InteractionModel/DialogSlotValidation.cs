using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    [JsonConverter(typeof(DialogSlotValidationConverter))]
    public abstract class DialogSlotValidation
    {
        [JsonProperty("type")]
        public abstract string Type { get; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }
    }
}