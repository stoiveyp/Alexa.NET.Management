using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeImportStatusResults
    {
        [JsonProperty("paginationContext", NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContextWithTotalCount PaginationContext { get; set; }

        [JsonProperty("knowledgeImports",NullValueHandling = NullValueHandling.Ignore)]
        public KnowledgeImportStatus[] KnowledgeImports { get; set; }
    }
}
