using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class Locale
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("examplePhrases")]
        public string[] ExamplePhrases { get; set; }

        [JsonProperty("keywords")]
        public string[] Keywords { get; set; }

        [JsonProperty("smallIconUri")]
        public Uri SmallIcon { get; set; }

        [JsonProperty("largeIconUri")]
        public Uri LargeIcon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}