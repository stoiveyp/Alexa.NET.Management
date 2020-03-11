using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreateSlotResponse
    {
        [JsonProperty("slotType")]
        public CreateSlotResponseType SlotType { get; set; }
    }
}