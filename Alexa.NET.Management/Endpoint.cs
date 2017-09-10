using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class Endpoint
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}