using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class SubscriptionProduct:Product
    {
        [JsonProperty("subscriptionInformation")]
        public SubscriptionInformation SubscriptionInformation { get; set; }
        public override string Type => SubscriptionType;

    }
}
