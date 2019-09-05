using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.NluEvaluation
{
    public class ListResponse
    {
        [JsonProperty("annotationSets")]
        public AnnotationSetProperties[] AnnotationSets { get; set; }

        [JsonProperty("paginationContext")]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}
