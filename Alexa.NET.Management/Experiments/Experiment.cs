using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class Experiment
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExperimentType Type { get; set; }

        [JsonProperty("plannedDuration")]
        public string PlannedDuration { get; set; }

        [JsonProperty("exposurePercentage")]
        public int ExposurePercentage { get; set; }

        [JsonProperty("metricConfigurations")]
        public List<MetricConfiguration> MetricConfigurations { get; set; } = new List<MetricConfiguration>();
    }
}