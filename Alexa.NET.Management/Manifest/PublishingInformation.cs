using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class PublishingInformation
    {
        [JsonProperty("locales")]
        public Dictionary<string,Locale> Locales { get; set; }

        [JsonProperty("isAvailableWorldwide")]
        public bool IsAvailableWorldwide { get; set; }

        [JsonProperty("testingInstructions")]
        public string TestingInstructions { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("distributionCountries")]
        public string[] DistributionCountries { get; set; }

        [JsonProperty("gadgetSupport",NullValueHandling = NullValueHandling.Ignore)]
        public GadgetSupport GadgetSupport { get; set; }
    }
}