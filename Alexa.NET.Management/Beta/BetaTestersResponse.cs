using Newtonsoft.Json;

namespace Alexa.NET.Management.Beta
{
    public class BetaTestersResponse
    {
        [JsonProperty("nextToken")]
        public string NextToken { get; set; }

        [JsonProperty("isTruncated")]
        public string IsTruncated { get; set; }

        [JsonProperty("testers")]
        public Tester[] Testers { get; set; }
    }
}
