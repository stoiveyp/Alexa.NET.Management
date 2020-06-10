using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationStatusResult
    {
        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public EvaluationResultStatus Status { get; set; }

        [JsonProperty("metrics")]
        public EvaluationStatusMetrics Metrics { get; set; }
    }
}