using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class LastModifiedInformation
    {
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public SkillStatusState Status { get; set; }
    }
}