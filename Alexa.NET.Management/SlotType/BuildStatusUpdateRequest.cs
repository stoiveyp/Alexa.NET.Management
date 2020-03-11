using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class BuildStatusUpdateRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}