using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class ReviewTrackingSummary
    {
        [JsonProperty("estimatedCompletionTimestamp")]
        public DateTime EstimatedCompletionTimestamp { get; set; }

        [JsonProperty("actualCompletionTimestamp")]
        public DateTime ActualCompletionTimestamp { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}