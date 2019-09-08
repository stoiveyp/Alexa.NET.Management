using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class PaginationContextWithTotalCount:PaginationContext
    {
        [JsonProperty("totalCount")]
        public string TotalCount { get; set; }
    }
}