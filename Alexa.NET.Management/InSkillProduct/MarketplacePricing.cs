using System;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class MarketplacePricing
    {
        [JsonProperty("releaseDate")]
        public DateTime ReleaseDateUtc { get; set; }

        [JsonProperty("defaultPriceListing")]
        public PriceListing DefaultPriceListing { get; set; }
    }
}