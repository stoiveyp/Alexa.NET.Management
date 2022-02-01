using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentHistory
    {
        [JsonProperty("creationTime",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreationTime { get; set; }

        [JsonProperty("startTime",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartTime { get; set; }

        [JsonProperty("stoppedReason",NullValueHandling = NullValueHandling.Ignore)]
        public string StoppedReason { get; set; }
    }
}