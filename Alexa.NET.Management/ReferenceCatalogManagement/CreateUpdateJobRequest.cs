using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class CreateUpdateJobRequest
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("jobDefinition")]
        public IUpdateJobDefinition JobDefinition { get; set; }
    }
}
