using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class ListSubscriberResponse
    {
        [JsonProperty("_links",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("nextToken",NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("subscribers")]
        public ListedSubscriber[] Subscribers { get; set; }
    }
}
