using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApiInterface
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}