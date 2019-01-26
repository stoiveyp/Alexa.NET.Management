using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class PublicationFailure
    {
        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("countries")]
        public string[] Countries { get; set; }
    }
}