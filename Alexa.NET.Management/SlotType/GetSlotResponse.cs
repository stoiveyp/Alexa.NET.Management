using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class GetSlotResponse
    {
        [JsonProperty("slotType")]
        public SharedSlotType SlotType { get; set; }
    }
}