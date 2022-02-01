using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class MetricConfiguration
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("metricTypes")]
        public List<MetricType> MetricTypes { get; set; } = new List<MetricType>();

        [JsonProperty("expectedChange")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MetricConfigurationChange ExpectedChange { get; set; }
    }
}