using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Alexa.NET.Management.Internals
{
    public class SkillValidationRequest
    {
        [JsonProperty("locales")]
        public string[] Locales { get; set; }
    }
}