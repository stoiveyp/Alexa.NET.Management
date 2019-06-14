using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class UnpublishResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}