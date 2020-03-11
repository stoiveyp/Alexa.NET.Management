using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class UpdateRequest
    {
        [JsonProperty("slotType")]
        public SlotDescription SlotType { get; set; }
    }
}