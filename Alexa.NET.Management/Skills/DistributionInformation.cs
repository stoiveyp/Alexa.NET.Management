using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class DistributionInformation
    {
        [JsonProperty("publishedCountries")]
        public string[] PublishedCountries { get; set; }

        [JsonProperty("publicationFailures")]
        public PublicationFailure[] PublicationFailures { get; set; }
    }
}