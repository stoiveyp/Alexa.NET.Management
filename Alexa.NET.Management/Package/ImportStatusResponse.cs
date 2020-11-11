using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Alexa.NET.Management.Package
{
    public class ImportStatusResponse
    {
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public ImportStatus Status { get; set; }

        [JsonProperty("skill")]
        public ImportStatusSkill Skill { get; set; }
    }
}
