using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class UpdateJobSummary
    {
        [JsonProperty("jobId")]
        public string JobId { get; set; }

        [JsonProperty("jobType")]
        public string JobType { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateJobStatus Status { get; set; }
    }
}