using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.AnnotationSet
{
    public class UpdateAnnotationsRequest
    {
        [JsonProperty("annotations")]
        public AnnotationUpdate[] Annotations { get; set; }
    }
}
