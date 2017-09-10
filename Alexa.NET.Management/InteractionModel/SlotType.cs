using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class SlotType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public string[] Values { get; set; }
    }
}