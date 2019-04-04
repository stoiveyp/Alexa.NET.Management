using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class InteractionModelVersionLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}