using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InteractionModel
{
    public class SkillModelVersionSummary
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}