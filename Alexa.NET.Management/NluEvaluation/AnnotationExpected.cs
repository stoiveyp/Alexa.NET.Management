using Newtonsoft.Json;

namespace Alexa.NET.Management.NluEvaluation
{
    public class AnnotationExpected
    {
        [JsonProperty("intent")]
        public AnnotationIntent Intent { get; set; }
    }
}