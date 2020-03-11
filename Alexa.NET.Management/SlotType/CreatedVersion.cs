using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreatedVersion
    {
        [JsonProperty("slotType")]
        public CreatedVersionSlotType SlotType { get; set; }
    }
}