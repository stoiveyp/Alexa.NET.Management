using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class CatalogScheduleTrigger:IUpdateJobTrigger
    {
        [JsonProperty("type")] public string Type => "Schedule";
        [JsonProperty("hour")]
        public int Hour { get; set; }

        [JsonProperty("dayOfWeek",NullValueHandling = NullValueHandling.Ignore)]
        public int? DayOfWeek { get; set; }
    }
}