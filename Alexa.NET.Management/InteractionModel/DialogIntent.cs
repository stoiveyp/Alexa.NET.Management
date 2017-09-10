using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class DialogIntent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slots")]
        public DialogSlot[] Slots { get; set; }
    }
}