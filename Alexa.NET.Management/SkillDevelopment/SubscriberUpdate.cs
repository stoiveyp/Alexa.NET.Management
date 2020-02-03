using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SubscriberUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("endpoint")]
        public SubscriptionEndpoint Endpoint { get; set; }
    }
}
