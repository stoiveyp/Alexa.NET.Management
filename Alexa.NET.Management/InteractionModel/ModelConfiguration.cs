using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class ModelConfiguration
    {
        [JsonProperty("fallbackIntentSensitivity",NullValueHandling = NullValueHandling.Ignore)]
        public FallbackIntentSensitivity FallbackIntentSensitivity { get; set; }
    }
}