using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class GadgetSupport
    {
        [JsonProperty("requirement")]
        public string Requirement { get; set; }

        [JsonProperty("numPlayersMin")]
        public int MinPlayers { get; set; }

        [JsonProperty("numPlayersMax")]
        public int MaxPlayers { get; set; }

        [JsonProperty("minGadgetButtons")]
        public int MinButtons { get; set; }
    }
}