using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class ReferenceCatalogUpdateStatus
    {
        [JsonProperty("lastUpdateRequest")]
        public ReferenceCatalogUpdateStatusRequest LastUpdateRequest { get; set; }
    }
}
