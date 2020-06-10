using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationStatusMetrics
    {
        [JsonProperty("overallErrorRate")]
        public double OverallErrorRate { get; set; }
    }
}