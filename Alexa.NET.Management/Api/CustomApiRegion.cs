using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApiRegion
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }
    }
}