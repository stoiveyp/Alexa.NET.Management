using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentHistory
{
    public class IntentRequestHistoryLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}