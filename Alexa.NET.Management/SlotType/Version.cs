using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.SlotType
{
    public class Version
    {
        [JsonProperty("slotType")]
        public VersionSlotType SlotType { get; set; }
    }
}
