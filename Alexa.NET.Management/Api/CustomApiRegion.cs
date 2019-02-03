using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApiRegion
    {
        [JsonProperty("endpoint")]
        public CustomApiEndpoint Endpoint { get; set; }
    }
}