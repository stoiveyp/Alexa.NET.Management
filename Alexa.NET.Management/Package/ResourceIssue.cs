using Newtonsoft.Json;

namespace Alexa.NET.Management.Package
{
    public class ResourceIssue
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}