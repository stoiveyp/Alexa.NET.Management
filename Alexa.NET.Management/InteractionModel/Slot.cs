using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class Slot
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("samples",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Samples { get; set; }

        [JsonProperty("multipleValues",NullValueHandling = NullValueHandling.Ignore)]
        public MultipleSlotValues MultipleValues { get; set; }
    }
}