using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillSummaryLink {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}