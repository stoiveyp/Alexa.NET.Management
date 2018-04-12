using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentRequestHistory
{
    public class IntentRequestHistoryLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}