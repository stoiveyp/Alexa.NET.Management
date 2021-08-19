using Newtonsoft.Json;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeImportStatusResult
    {
        [JsonProperty("knowledgeImport")]
        public KnowledgeImportStatus KnowledgeImport { get; set; }
    }
}