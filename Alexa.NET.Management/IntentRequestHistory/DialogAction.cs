using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentRequestHistory
{
    public class DialogAction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}