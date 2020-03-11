using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreateSlotResponseType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}