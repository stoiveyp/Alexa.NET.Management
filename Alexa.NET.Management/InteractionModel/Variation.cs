using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.InteractionModel
{
    public class Variation
    {
        [JsonProperty("type"),JsonConverter(typeof(StringEnumConverter))]
        public VariationType Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}