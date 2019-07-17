using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApiTask
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}