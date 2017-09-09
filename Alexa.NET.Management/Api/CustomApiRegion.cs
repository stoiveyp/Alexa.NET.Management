using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApiRegion
    {
        [JsonProperty("endpoint")]
        public CustomApiRegionEndpoint Endpoint { get; set; }
    }
}