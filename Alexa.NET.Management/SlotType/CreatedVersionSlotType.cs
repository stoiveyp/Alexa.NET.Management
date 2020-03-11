using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreatedVersionSlotType : VersionSlotType
    {
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}