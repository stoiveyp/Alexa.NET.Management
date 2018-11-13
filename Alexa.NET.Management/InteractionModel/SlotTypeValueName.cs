using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class SlotTypeValueName
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("synonyms")]
        public string[] Synonyms { get; set; }
    }
}