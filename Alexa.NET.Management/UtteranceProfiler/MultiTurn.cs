using Newtonsoft.Json;

namespace Alexa.NET.Management.UtteranceProfiler
{
    public class MultiTurn
    {
        [JsonProperty("dialogAct")]
        public DialogAct DialogAct { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }
    }
}