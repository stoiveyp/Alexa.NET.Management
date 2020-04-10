using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Audit
{
    public class QueryResponse
    {
        [JsonProperty("paginationContext",NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContext PaginationContext { get; set; }

        [JsonProperty("auditLogs")]
        public AuditLog[] AuditLogs { get; set; }
    }
}
