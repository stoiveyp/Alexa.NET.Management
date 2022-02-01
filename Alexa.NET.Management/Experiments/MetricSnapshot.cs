using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class MetricSnapshot
    {
        [JsonProperty("metricSnapshotId",NullValueHandling = NullValueHandling.Ignore)]
        public string MetricSnapshotId { get; set; }

        [JsonProperty("startDate",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EndDate { get; set; }
    }
}