using Newtonsoft.Json;

namespace Alexa.NET.Management.UtteranceProfiler
{
    public class UtteranceProfilerRequest
    {
        [JsonProperty("utterance")]
        public string Utterance { get; set; }

        [JsonProperty("multiTurnToken",NullValueHandling = NullValueHandling.Ignore)]
        public string MultiTurnToken { get; set; }

        public UtteranceProfilerRequest(string utterance, string multiTurnToken)
        {
            Utterance = utterance;
            MultiTurnToken = multiTurnToken;
        }
    }
}
