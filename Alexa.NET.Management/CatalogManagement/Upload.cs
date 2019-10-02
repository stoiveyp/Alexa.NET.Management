using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.CatalogManagement
{
    public class Upload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("catalogId")]
        public string CatalogId { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UploadStatus UploadStatus { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("lastUpdatedTime")]
        public DateTime LastUpdatedTime { get; set; }

        [JsonProperty("file")]
        public UploadFile File { get; set; }

        [JsonProperty("ingestionSteps")]
        public IngestionStep[] IngestionSteps { get; set; }
    }
}
