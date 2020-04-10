using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Audit
{
    public class Resource
    {
        public Resource() { }

        public Resource(string id, ResourceType type)
        {
            Id = id;
            Type = type;
        }

        [JsonProperty("id",NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("type",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceType? Type { get; set; }
    }
}