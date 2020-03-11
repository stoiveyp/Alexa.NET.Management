using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class ListSlotResponse
    {
        [JsonProperty("nextToken",NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("slotTypes")]
        public LinkedSharedSlotType[] SlotTypes { get; set; }
    }

    public class ListSlotVersionsResponse
    {
        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, ApiLink> Links { get; set; }

        [JsonProperty("slotTypeVersions")]
        public LinkedVersion[] SlotTypeVersions { get; set; }
    }
}
