using Alexa.NET.Management.Vendors;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class VendorResponse
    {
        [JsonProperty("vendors")]
        public Vendor[] Vendors { get; set; }
    }
}