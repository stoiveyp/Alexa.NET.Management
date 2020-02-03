using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class Subscription
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("events")]
        public AlexaDevelopmentEventType[] Events { get; set; }

        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }
    }
}
