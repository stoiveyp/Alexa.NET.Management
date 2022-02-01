using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class GetTreatmentOverrideResponse
    {
        [JsonProperty("treatmentId")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TreatmentId TreatmentId { get; set; }

        [JsonProperty("treatmentOverrideCount")]
        public int TreatmentOverrideCount { get; set; }
    }
}
