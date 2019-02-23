using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class PrivacyAndCompliance
    {
        [JsonProperty("allowsPurchases")]
        public bool AllowPurchases { get; set; } 

        [JsonProperty("usesPersonalInfo")]
        public bool UsesPersonalInfo { get; set; }

        [JsonProperty("isChildDirected")]
        public bool IsChildDirected { get; set; }

        [JsonProperty("isExportCompliant")]
        public bool IsExportCompliant { get; set; }

        [JsonProperty("containsAds")]
        public bool ContainsAds { get; set; }

        [JsonProperty("locale")]
        public Dictionary<string,PrivacyAndCompliantLocale> Locales { get; set; }
    }
}
