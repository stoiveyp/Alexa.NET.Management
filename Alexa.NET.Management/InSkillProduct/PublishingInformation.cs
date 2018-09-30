using System.Collections.Generic;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class PublishingInformation
    {
        [JsonProperty("locales")]
        public Dictionary<string, LocalePublishingInformation> Locales { get; set; } = new Dictionary<string, LocalePublishingInformation>();

        [JsonProperty("distributionCountries")]
        public List<string> DistributionCountries { get; set; } = new List<string>();

        [JsonProperty("pricing")]
        public Dictionary<string,MarketplacePricing> Pricing { get; set; }

        [JsonIgnore]
        public MarketplacePricing AmazonMarketplace {
            get
            {
                if (Pricing.ContainsKey("amazon.com"))
                {
                    return Pricing["amazon.com"];
                }
                var amazonMarketplace = new MarketplacePricing();
                Pricing.Add("amazon.com",amazonMarketplace);
                return amazonMarketplace;

            }
            set
            {
                Pricing = Pricing ?? new Dictionary<string, MarketplacePricing>();
                if (Pricing.ContainsKey("amazon.com"))
                {
                    Pricing.Remove("amazon.com");
                }

                Pricing.Add("amazon.com", value);
            }
        }

        [JsonProperty("taxInformation")]
        public TaxInformation TaxInformation { get; set; }
    }
}