using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogCreationResponse
    {
        [JsonProperty("catalogId")]
        public string CatalogId { get; set; }
    }
}
