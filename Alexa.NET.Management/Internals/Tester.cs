using Newtonsoft.Json;

namespace Alexa.NET.Management.Internals
{
    public class TesterEmail
    {
        [JsonProperty("emailId")]
        public string Email { get; set; }
    }
}