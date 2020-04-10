using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public class EvaluationStatus
    {
        [JsonProperty("startTimestamp"),
        JsonConverter(typeof(Iso8601Converter))]
        public DateTime StartTimestamp { get; set; }

        [JsonProperty("endTimestamp",NullValueHandling = NullValueHandling.Ignore),
         JsonConverter(typeof(Iso8601Converter))]
        public DateTime? EndTimestamp { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("inputs")]
        public CreateEvaluationRequest Inputs { get; set; }
    }
}