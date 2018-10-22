using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Package
{
    public class CreatePackageRequest
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}
