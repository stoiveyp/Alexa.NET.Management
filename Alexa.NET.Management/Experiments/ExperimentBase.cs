using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentBase
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("plannedDuration")]
        public string PlannedDuration { get; set; }

        [JsonProperty("exposurePercentage")]
        public int ExposurePercentage { get; set; }

        [JsonProperty("metricConfigurations")]
        public List<MetricConfiguration> MetricConfigurations { get; set; } = new List<MetricConfiguration>();
    }
}