using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class CertificationLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
