using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class SkillId
    {
        [JsonProperty("skill_id")]
        public string Id { get; set; }
    }
}
