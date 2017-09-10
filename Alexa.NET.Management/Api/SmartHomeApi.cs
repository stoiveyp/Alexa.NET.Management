using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class SmartHomeApi:IApi
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("regions")]
        public Dictionary<string, CustomApiRegion> Regions { get; set; }
    }
}