using Newtonsoft.Json;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeTemplateIdResults
    {
        [JsonProperty("paginationContext",NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContextWithTotalCount PaginationContext { get; set; }

        [JsonProperty("templates",NullValueHandling = NullValueHandling.Ignore)]
        public KnowledgeTemplateId[] Templates { get; set; }
    }
}