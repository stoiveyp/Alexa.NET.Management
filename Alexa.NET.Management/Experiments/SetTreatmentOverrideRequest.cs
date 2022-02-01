using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    public class SetTreatmentOverrideRequest
    {
        [JsonProperty("treatmentId")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TreatmentId TreatmentId { get; set; }
    }
}