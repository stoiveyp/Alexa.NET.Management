using Newtonsoft.Json;

namespace Alexa.NET.Management.Package
{
    public class ResourceIssue
    {
        [JsonProperty("code",NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}