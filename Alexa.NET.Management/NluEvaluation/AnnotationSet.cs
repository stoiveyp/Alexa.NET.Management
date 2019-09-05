using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.NluEvaluation
{
    public class AnnotationSet
    {
        [JsonProperty("data")]
        public Annotation[] Data { get; set; }
    }
}
