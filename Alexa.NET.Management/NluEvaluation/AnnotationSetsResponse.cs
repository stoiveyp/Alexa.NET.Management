using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.NluEvaluation
{
    public class AnnotationSetsResponse
    {
        [JsonProperty("annotationSets")]
        public AnnotationSet[] AnnotationSets { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}
