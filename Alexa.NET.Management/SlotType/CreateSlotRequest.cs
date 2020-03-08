using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreateSlotRequest
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("slotType")]
        public SharedSlotType SlotType { get; set; }
    }
}
