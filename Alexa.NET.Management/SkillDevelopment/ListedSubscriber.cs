using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class ListedSubscriber : SubscriberUpdate
    {
        [JsonProperty("subscriberId")]
        public string SubscriptionId { get; set; }
    }
}