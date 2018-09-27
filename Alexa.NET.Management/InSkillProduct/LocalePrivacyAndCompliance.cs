using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class LocalePrivacyAndCompliance
    {
        [JsonProperty("privacyPolicyUrl")]
        public Uri PrivacyPolicyUrl { get; set; }
    }
}
