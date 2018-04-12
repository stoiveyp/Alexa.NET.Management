using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentHistory
{
    public class DialogAction
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}