using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    internal class ChangeStatusRequest
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdateJobStatus Status { get; set; }
    }
}
