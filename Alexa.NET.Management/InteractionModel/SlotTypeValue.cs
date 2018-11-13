using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class SlotTypeValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public SlotTypeValueName Name { get; set; }
    }
}