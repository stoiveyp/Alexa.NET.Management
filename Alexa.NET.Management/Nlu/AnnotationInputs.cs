using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class AnnotationInputs
    {
        [JsonProperty("utterance")]
        public string Utterance { get; set; }
        [JsonProperty("referenceTimestamp",NullValueHandling = NullValueHandling.Ignore),
         JsonConverter(typeof(Iso8601Converter))]
        public DateTime? ReferenceTimestamp { get; set; }
    }
}