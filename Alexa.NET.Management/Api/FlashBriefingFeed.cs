using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Api
{
    public class FlashBriefingFeed
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("vuiPreamble")]
        public string VuiPremable { get; set; }

        [JsonProperty("updateFrequency"),JsonConverter(typeof(StringEnumConverter))]
        public UpdateFrequency UpdateFrequency { get; set; }

        [JsonProperty("genre"), JsonConverter(typeof(StringEnumConverter))]
        public ContentGenre ContentGenre { get; set; }

        [JsonProperty("imageUri")]
        public string ImageUri { get; set; }

        [JsonProperty("contentType"), JsonConverter(typeof(StringEnumConverter))]
        public ContentFeedType ContentType { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}