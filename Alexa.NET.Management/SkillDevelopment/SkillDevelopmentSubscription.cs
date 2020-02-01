using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SkillDevelopmentSubscription
    {
        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }
    }
}