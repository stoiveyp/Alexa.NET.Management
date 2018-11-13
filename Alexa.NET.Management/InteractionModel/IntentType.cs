using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class IntentType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots",NullValueHandling = NullValueHandling.Ignore)]
        public Slot[] Slots { get; set; }

        [JsonProperty("samples",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Samples { get; set; }
    }
}