using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class Subscriber:SubscriberUpdate
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }
    }
}
