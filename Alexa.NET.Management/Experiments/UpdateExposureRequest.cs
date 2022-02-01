using Newtonsoft.Json;

namespace Alexa.NET.Management.Experiments
{
    internal class UpdateExposureRequest
    {
        [JsonProperty("exposurePercentage", NullValueHandling = NullValueHandling.Ignore)]
        public int ExposurePercentage { get; set; }
    }
}
