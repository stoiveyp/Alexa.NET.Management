using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public class KnowledgeImportDataRequest
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("importContent",NullValueHandling = NullValueHandling.Ignore)]
        public string ImportContent { get; set; }

        [JsonProperty("template",NullValueHandling = NullValueHandling.Ignore)]
        public KnowledgeTemplateId Template { get; set; }
    }
}
