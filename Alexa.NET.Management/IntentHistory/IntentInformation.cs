using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentHistory
{
    public class IntentInformation
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}