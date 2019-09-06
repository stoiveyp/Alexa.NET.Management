using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class ListAnnotationSetResponse
    {
        [JsonProperty("annotationSets")]
        public AnnotationSetProperties[] AnnotationSets { get; set; }

        [JsonProperty("paginationContext")]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}
