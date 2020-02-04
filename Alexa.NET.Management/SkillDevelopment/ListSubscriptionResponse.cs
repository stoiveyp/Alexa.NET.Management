using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class ListSubscriptionResponse
    {
        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("subscriptions")]
        public ListedSubscription[] Subscriptions{ get; set; }
    }
}