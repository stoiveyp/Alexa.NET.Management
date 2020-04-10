using System;
using System.Net;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Audit
{
    public class AuditLog
    {
        [JsonProperty("xAmznRequestId")]
        public string AmazonRequestId { get; set; }

        [JsonProperty("httpResponseCode",NullValueHandling = NullValueHandling.Ignore)]
        public HttpStatusCode HttpResponseCode { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(Iso8601Converter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("operation")]
        public Operation Operation { get; set; }

        [JsonProperty("resources",NullValueHandling = NullValueHandling.Ignore)]
        public Resource[] Resources { get; set; }

        [JsonProperty("requester")]
        public Requester Requester { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }
    }
}