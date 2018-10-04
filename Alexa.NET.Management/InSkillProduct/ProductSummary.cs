using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class ProductSummary
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("status")]
        public ProductStatus Status { get; set; }

        [JsonProperty("editableState")]
        public string EditableState { get; set; }

        [JsonProperty("stage")]
        public SkillStage Stage { get; set; }

        [JsonProperty("purchasableState")]
        public string PurchasableState { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string,InProductLink> Links { get; set; }

        [JsonProperty("nameByLocale")]
        public Dictionary<string,string> NameByLocale { get; set; }

        [JsonProperty("pricing")]
        public Dictionary<string, MarketplaceSummaryPricing> Pricing { get; set; }

        [JsonIgnore]
        public MarketplaceSummaryPricing AmazonMarketplace => Pricing.ContainsKey("amazon.com") ? Pricing["amazon.com"] : null;
    }
}
