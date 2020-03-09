using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class UpdateSlotRequest
    {
        [JsonProperty("slotType")]
        public SlotDescription SlotType { get; set; }
    }
}