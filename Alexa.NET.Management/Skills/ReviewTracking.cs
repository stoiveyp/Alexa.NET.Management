using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class ReviewTracking:ReviewTrackingSummary
    {
        [JsonProperty("estimationUpdates")]
        public EstimationUpdate[] EstimationUpdates { get; set; }
    }
}