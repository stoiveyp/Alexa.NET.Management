using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class LinkedVersion
    {
        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}