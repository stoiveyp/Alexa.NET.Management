using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public EvaluationStatusState Status { get; set; }
        
        [JsonProperty("totalEvaluationCount")]
        public int TotalEvaluationCount { get; set; }

        [JsonProperty("completedEvaluationCount")]
        public int CompletedEvaluationCount { get; set; }

        [JsonProperty("startTimestamp"),JsonConverter(typeof(Iso8601Converter))]
        public DateTime StartTimestamp { get; set; }

        [JsonProperty("request")]
        public RunEvaluationsRequest Request { get; set; }

        [JsonProperty("result",NullValueHandling = NullValueHandling.Ignore)]
        public EvaluationStatusResult Result { get; set; }

        [JsonProperty("error",NullValueHandling = NullValueHandling.Ignore)]
        public EvaluationError Error { get; set; }
    }
}
