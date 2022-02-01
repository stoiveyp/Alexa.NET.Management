using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class PaginationContext
    {
        [JsonProperty("nextToken",NullValueHandling = NullValueHandling.Ignore)]
        public string NextToken { get; set; }

        [JsonProperty("previousToken",NullValueHandling = NullValueHandling.Ignore)]
        public string PreviousToken { get; set; }
    }
}
