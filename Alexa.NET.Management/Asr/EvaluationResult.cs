using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationResult
    {
        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public EvaluationResultStatus Status { get; set; }

        [JsonProperty("annotation")]
        public Asr.AnnotationSet.Annotation Annotation { get; set; }

        [JsonProperty("output",NullValueHandling = NullValueHandling.Ignore)]
        public EvaluationResultOutput Output { get; set; }

        [JsonProperty("error",NullValueHandling = NullValueHandling.Ignore)]
        public EvaluationError Error { get; set; }
    }
}