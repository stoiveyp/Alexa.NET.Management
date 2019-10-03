using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class IngestionStepError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}