using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class CatalogAutoRefreshJob: IUpdateJobDefinition
    {
        [JsonProperty("type")]
        public string Type => "CatalogAutoRefresh";

        [JsonProperty("resource")]
        public CatalogResource Resource { get; set; }

        [JsonProperty("trigger")]
        public CatalogScheduleTrigger Trigger { get; set; }

        [JsonProperty("status")]
        public UpdateJobStatus? Status { get; set; }
    }
}