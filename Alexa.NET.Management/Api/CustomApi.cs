using System.Collections.Generic;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApi:IApi
    {
        [JsonProperty("endpoint", NullValueHandling = NullValueHandling.Ignore)]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("regions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, CustomApiRegion> Regions { get; set; }

        [JsonProperty("interfaces", NullValueHandling = NullValueHandling.Ignore)]
        public CustomApiInterface[] Interfaces { get; set; }

        [JsonProperty("tasks",NullValueHandling = NullValueHandling.Ignore)]
        public CustomApiTask[] Tasks { get; set; }
    }
}