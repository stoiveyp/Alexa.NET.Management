using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class Subscriber
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("endpoint")]
        public SubscriptionEndpoint Endpoint { get; set; }
    }
}
