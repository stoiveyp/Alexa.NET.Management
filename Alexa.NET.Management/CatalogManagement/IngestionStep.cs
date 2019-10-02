using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.CatalogManagement
{
    public class IngestionStep
    {
        [JsonProperty("name")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IngestionStepName Name { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IngestionStepStatus Status { get; set; }

        [JsonProperty("logUrl")]
        public Uri LogUrl { get; set; }

        [JsonProperty("errors")]
        public IngestionStepError[] Errors { get; set; }
    }
}