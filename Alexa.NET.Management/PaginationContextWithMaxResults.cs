using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class PaginationContextWithMaxResults:PaginationContext
    {
        [JsonProperty("maxResults",NullValueHandling = NullValueHandling.Ignore)]
        public int MaxResults { get; set; }
    }
}