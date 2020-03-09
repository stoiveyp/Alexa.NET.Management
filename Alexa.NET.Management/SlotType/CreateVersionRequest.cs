using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class CreateVersionRequest
    {
        [JsonProperty("slotType")]
        public CreateVersionSlotType SlotType { get; set; }
    }
}
