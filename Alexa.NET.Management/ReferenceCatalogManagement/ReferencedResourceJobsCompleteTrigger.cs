using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferencedResourceJobsCompleteTrigger : IUpdateJobTrigger
    {
        [JsonProperty("type")]
        public string Type => "ReferencedResourceJobsComplete";
    }
}