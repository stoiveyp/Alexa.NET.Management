using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Audit
{
    public class QueryRequest
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("paginationContext", NullValueHandling = NullValueHandling.Ignore)]
        public PaginationContextWithMaxResults PaginationContext { get; set; }

        [JsonProperty("sortDirection", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SortDirectionUpperCaseConverter))]
        public SortDirection? SortDirection { get; set; }

        [JsonProperty("sortField", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SortField? SortField { get; set; }

        [JsonProperty("requestFilters", NullValueHandling = NullValueHandling.Ignore)]
        public RequestFilters RequestFilters { get; set; }
    }

    public class RequestFilters
    {
        [JsonProperty("startTime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Iso8601Converter))]
        public DateTime? StartTime { get; set; }

        [JsonProperty("endTime", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(Iso8601Converter))]
        public DateTime? EndTime { get; set; }

        [JsonProperty("httpResponseCodes", NullValueHandling = NullValueHandling.Ignore)]
        public string[] HttpResponseCodes { get; set; }

        [JsonProperty("operations", NullValueHandling = NullValueHandling.Ignore)]
        public Operation[] Operations { get; set; }

        [JsonProperty("requesters",NullValueHandling = NullValueHandling.Ignore)]
        public Requester[] Requesters { get; set; }

        [JsonProperty("resources",NullValueHandling = NullValueHandling.Ignore)]
        public Resource[] Resources { get; set; }
    }
}
