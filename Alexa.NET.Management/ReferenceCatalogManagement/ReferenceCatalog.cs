using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalog
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description",NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }
}
