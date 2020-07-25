using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class MultipleSlotValues
    {
        public static MultipleSlotValues IsEnabled() => new MultipleSlotValues { Enabled = true };

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    }
}