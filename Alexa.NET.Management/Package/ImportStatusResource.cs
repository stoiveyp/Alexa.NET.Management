using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Package
{
    public class ImportStatusResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceStatus Status { get; set; }

        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceAction Action { get; set; }

        [JsonProperty("info",NullValueHandling = NullValueHandling.Ignore)]
        public ResourceIssue[] Info { get; set; }

        [JsonProperty("errors")]
        public ResourceIssue[] Errors { get; set; }

        [JsonProperty("warnings")]
        public ResourceIssue[] Warnings { get; set; }
    }
}