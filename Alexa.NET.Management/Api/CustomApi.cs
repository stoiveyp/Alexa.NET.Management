using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApi:IApi
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("regions")]
        public Dictionary<string, CustomApiRegion> Regions { get; set; }

        [JsonProperty("interfaces")]
        public CustomApiInterface[] Interfaces { get; set; }

        [JsonProperty("tasks",NullValueHandling = NullValueHandling.Ignore)]
        public CustomApiTask[] Tasks { get; set; }
    }
}