using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Skills
{
    public class InvocationResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status"),JsonConverter(typeof(StringEnumConverter))]
        public InvocationStatus Status { get; set; }

        [JsonProperty("result")]
        public InvocationResult Result { get; set; }
    }
}