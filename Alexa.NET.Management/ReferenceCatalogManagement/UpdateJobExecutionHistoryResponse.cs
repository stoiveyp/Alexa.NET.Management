using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class UpdateJobExecutionHistoryResponse
    {
        [JsonProperty("executions",NullValueHandling = NullValueHandling.Ignore)]
        public UpdateJobExecution[] Executions { get; set; }

        [JsonProperty("paginationContext",NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("_links",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,ApiLink> Links { get; set; }
    }
}
