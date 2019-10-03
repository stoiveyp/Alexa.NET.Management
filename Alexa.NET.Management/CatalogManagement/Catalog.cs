using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class Catalog
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("catalogId")]
        public string CatalogId { get; set; }

        [JsonProperty("status")]
        public CatalogStatus Status { get; set; }

        [JsonProperty("createdDate",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("lastUpdatedDate",NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastUpdatedDate { get; set; }

        [JsonProperty("associatedSkillIds")]
        public string[] AssociatedSkillIds { get; set; }
    }
}
