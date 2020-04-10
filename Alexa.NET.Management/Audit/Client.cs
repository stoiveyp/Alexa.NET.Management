using Newtonsoft.Json;

namespace Alexa.NET.Management.Audit
{
    public class Client
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}