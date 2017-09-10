using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class Dialog
    {
        [JsonProperty("intents")]
        public DialogIntent[] Intents { get; set; }
    }
}