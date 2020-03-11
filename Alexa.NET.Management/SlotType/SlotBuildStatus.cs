using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class SlotBuildStatus
    {
        [JsonProperty("updateRequest")]
        public BuildStatusUpdateRequest UpdateRequest { get; set; }
    }
}
