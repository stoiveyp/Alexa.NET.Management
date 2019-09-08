using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class AnnotationSet
    {
        [JsonProperty("data")]
        public Annotation[] Data { get; set; }
    }
}
