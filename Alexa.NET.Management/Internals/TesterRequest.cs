using Newtonsoft.Json;

namespace Alexa.NET.Management.Internals
{
    public class TesterRequest
    {
        [JsonProperty("testers")]
        public TesterEmail[] Testers { get; set; }
    }
}