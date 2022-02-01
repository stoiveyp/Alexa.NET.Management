using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Api
{
    public class KnowledgeApi : IApi
    {

        [JsonProperty("locales",NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string,LocaleAttribution> Locales { get; set; }
    }
}