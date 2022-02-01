using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    public class ExperimentTrigger
    {
        [JsonProperty("scheduledEndTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ScheduledEndTime { get; set; }
    }
}