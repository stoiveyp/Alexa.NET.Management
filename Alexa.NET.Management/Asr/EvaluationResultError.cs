using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationResultError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}