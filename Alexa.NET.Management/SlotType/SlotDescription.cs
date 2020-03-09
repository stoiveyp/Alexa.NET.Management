using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class SlotDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}