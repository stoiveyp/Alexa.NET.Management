using Newtonsoft.Json;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public class EvaluationResultOutput
    {
        [JsonProperty("transcription")]
        public string Transcription { get; set; }
    }
}