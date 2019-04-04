using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Internals
{
    public class BuildStatus
    {
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public BuildStatusState Status { get; set; }
    }
}