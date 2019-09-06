using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class ListEvaluationResponse
    {
        [JsonProperty("evaluations")]
        public EvaluationStatus[] Evaluations { get; set; }

        [JsonProperty("paginationContext")]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}