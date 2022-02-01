using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeImportStatus
    {
        [JsonProperty("errors",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Errors { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public KnowledgeImportDescription Status { get; set; }
    }
}