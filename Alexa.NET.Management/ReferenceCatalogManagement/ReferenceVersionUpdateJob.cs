using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceVersionUpdateJob : IUpdateJobDefinition
    {
        [JsonProperty("type")]
        public string Type => "ReferenceVersionUpdate";
        [JsonProperty("resource")]
        public LocaleCatalogResource Resource { get; set; }

        [JsonProperty("references",NullValueHandling = NullValueHandling.Ignore)]
        public CatalogResource[] References { get; set; }

        [JsonProperty("trigger")]
        public IUpdateJobTrigger Trigger { get; set; } = new ReferencedResourceJobsCompleteTrigger();

        [JsonProperty("publishToLive")]
        public bool PublishToLive { get; set; }

        [JsonProperty("status")]
        public UpdateJobStatus? Status { get; set; }
    }
}