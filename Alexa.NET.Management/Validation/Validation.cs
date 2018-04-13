using Newtonsoft.Json;

namespace Alexa.NET.Management.Validation
{
    public class Validation
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("status")]
        public ValidationStatus Status { get; set; }

        [JsonProperty("importance")]
        public ValidationImportance Importance { get; set; }
    }
}