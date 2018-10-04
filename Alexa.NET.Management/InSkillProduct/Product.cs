using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public abstract class Product
    {
        public const string EntitlementType = "ENTITLEMENT";
        public const string SubscriptionType = "SUBSCRIPTION";
        public const string ConsumableType = "CONSUMABLE";
        protected Product()
        {
            Version = "1.0";
        }

        [JsonProperty("type")]
        public abstract string Type { get; }

        [JsonProperty("version")]
        public string Version { get; }

        [JsonProperty("referenceName")]
        public string ReferenceName { get; set; }

        [JsonProperty("publishingInformation")]
        public PublishingInformation PublishingInformation { get; set; }

        [JsonProperty("privacyAndCompliance")]
        public PrivacyAndCompliance PrivacyAndCompliance { get; set; }

        [JsonProperty("testingInstructions")]
        public string TestingInstructions { get; set; }

        [JsonProperty("purchasableState")]
        public string PurchasableState { get; set; }
    }
}
