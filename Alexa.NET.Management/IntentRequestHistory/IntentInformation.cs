using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentRequestHistory
{
    public class IntentInformation
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}