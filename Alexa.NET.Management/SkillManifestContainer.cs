using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.Manifest;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class SkillManifestContainer
    {
        [JsonProperty("skillManifest")]
        public SkillManifest SkillManifest { get; set; }
    }
}
