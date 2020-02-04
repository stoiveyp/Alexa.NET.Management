using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SubscriptionUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("events")]
        public AlexaDevelopmentEventType[] Events { get; set; }
    }
}
