using Newtonsoft.Json;

namespace Alexa.NET.Management.UtteranceProfiler
{
    public class DialogAct
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("targetSlot")]
        public string TargetSlot { get; set; }
    }
}