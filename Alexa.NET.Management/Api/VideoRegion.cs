using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class VideoRegion
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("upchannel")]
        public UpChannel UpChannel { get; set; }
    }
}