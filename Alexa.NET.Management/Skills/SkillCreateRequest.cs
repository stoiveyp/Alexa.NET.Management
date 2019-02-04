using Alexa.NET.Management.Manifest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alexa.NET.Management.Skills
{
    public class SkillCreateRequest
    {
        [JsonProperty("manifest")]
        public SkillManifest Manifest { get; set; }

        [JsonProperty("vendorId")]
        public string VendorId { get; set; }
    }
}
