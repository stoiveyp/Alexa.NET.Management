using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.AnnotationSet
{
    public class AnnotationExpected
    {
        [JsonProperty("intent")]
        public AnnotationIntent Intent { get; set; }
    }
}