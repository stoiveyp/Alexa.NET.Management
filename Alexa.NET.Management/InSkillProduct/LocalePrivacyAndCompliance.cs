using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class LocalePrivacyAndCompliance
    {
        public LocalePrivacyAndCompliance() { }

        public LocalePrivacyAndCompliance(string privacyPolicyUrl)
        {
            PrivacyPolicyUrl = privacyPolicyUrl;
        }

        [JsonProperty("privacyPolicyUrl")]
        public string PrivacyPolicyUrl { get; set; }
    }
}
