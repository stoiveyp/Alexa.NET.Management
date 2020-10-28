using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class UpdateJobExecution
    {
        [JsonProperty("executionId")]
        public string ExecutionId { get; set; }

        [JsonProperty("executionTimestamp"),
         JsonConverter(typeof(Iso8601Converter))]
        public DateTime LastUpdatedTimestamp { get; set; }

        [JsonProperty("errorCode",NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorCode { get; set; }

        [JsonProperty("status",NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateJobExecutionStatus Status { get; set; }

        [JsonProperty("errorDetails",NullValueHandling = NullValueHandling.Ignore)]
        public UpdateJobExecutionErrorDetails ErrorDetails { get; set; }
    }
}