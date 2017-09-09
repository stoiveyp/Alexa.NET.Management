using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class VideoLocale
    {
        [JsonProperty("videoProviderTargetingNames")]
        public string[] VideoProviderTargetingNames { get; set; }
    }
}