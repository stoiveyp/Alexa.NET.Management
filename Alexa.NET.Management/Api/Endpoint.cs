using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class Endpoint
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}