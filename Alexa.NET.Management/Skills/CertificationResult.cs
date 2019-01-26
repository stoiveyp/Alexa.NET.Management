using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class CertificationResult
    {
        [JsonProperty("distributionInfo")]
        public DistributionInformation DistributionInformation { get; set; }
    }
}