using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class IntentType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots")]
        public Slot[] Slots { get; set; }

        [JsonProperty("samples")]
        public string[] Samples { get; set; }
    }
}