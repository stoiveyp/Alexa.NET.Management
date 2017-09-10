using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management
{
    public class LastModifiedInformation
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public SkillStatusState Status { get; set; }
    }
}