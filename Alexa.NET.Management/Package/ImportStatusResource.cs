using Newtonsoft.Json;

namespace Alexa.NET.Management.Package
{
    public class ImportStatusResource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public ResourceStatus Status { get; set; }

        [JsonProperty("errors")]
        public ResourceIssue[] Errors { get; set; }

        [JsonProperty("warnings")]
        public ResourceIssue[] Warnings { get; set; }
    }
}