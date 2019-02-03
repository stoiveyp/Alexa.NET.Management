using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class CustomApi:IApi
    {
        [JsonProperty("endpoint")]
        public CustomApiEndpoint Endpoint { get; set; }

        [JsonProperty("regions")]
        public Dictionary<string, CustomApiRegion> Regions { get; set; }

        [JsonProperty("interfaces")]
        public CustomApiInterface[] Interfaces { get; set; }
    }

    public class CustomApiInterface
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}