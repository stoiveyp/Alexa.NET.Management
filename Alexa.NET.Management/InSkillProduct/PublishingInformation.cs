using System.Collections.Generic;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class PublishingInformation
    {
        [JsonProperty("locales")]
        public Dictionary<string, LocalePublishingInformation> Locales { get; } = new Dictionary<string, LocalePublishingInformation>();
    }
}