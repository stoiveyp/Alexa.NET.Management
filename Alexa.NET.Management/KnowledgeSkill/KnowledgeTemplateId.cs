using Newtonsoft.Json;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeTemplateId
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}