using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class CatalogAutoRefreshJob: IUpdateJobDefinition
    {
        [JsonProperty("type")]
        public string Type => "CatalogAutoRefresh";

        [JsonProperty("resource")]
        public CatalogResource Resource { get; set; }

        [JsonProperty("trigger")]
        public IUpdateJobTrigger Trigger { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateJobStatus? Status { get; set; }
    }
}