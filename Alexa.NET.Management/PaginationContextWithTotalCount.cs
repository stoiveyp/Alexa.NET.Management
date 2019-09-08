using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class PaginationContextWithTotalCount:PaginationContext
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
    }
}