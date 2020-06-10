using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationResults
    {
        [JsonProperty("paginationContext",NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("results")]
        public EvaluationResult[] Results { get; set; }
    }
}
