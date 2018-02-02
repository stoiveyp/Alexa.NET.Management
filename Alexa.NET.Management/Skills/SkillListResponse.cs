using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class SkillListResponse
    {
        [JsonProperty("skills")]
        public SkillSummary[] Skills { get; set; }
    }
}
