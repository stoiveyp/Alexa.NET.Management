using System;
using System.Collections.Generic;
using System.Text;
using Alexa.NET.Management.InteractionModel;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogValuesResponse
    {
        [JsonProperty("isTruncated", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTruncated { get; set; }

        [JsonProperty("values")]
        public SlotTypeValue[] Values { get; set; }


        [JsonProperty("nextToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("totalCount", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalCount { get; set; }

        [JsonProperty("_links", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ApiLink> Links { get; set; }
    }
}
