using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Metrics
{
    public class MetricsResponse
    {
        [JsonProperty("metric")]
        public string Metric { get; set; }

        [JsonProperty("timestamps")]
        public DateTime[] Timestamps { get; set; }

        [JsonProperty("values")]
        public double[] Values { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }
    }
}
