using Newtonsoft.Json;

namespace Alexa.NET.Management.Validation
{
    public class ValidationError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}