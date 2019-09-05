using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class PaginationContext
    {
        [JsonProperty("nextToken")]
        public string NextToken { get; set; }
    }
}
