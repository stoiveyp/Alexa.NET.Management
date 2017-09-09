using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class SkillManifest
    {
        [JsonProperty("publishingInformation")]
        public PublishingInformation PublishingInformation { get; set; }

        [JsonProperty("apis")]
        public Dictionary<string, Api.IApi> Apis { get; set; }

        [JsonProperty("manifestVersion")]
        public string Version { get; set; }

        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }
    }
}
