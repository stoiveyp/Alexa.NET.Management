using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    internal class ChangeStatusRequest
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public UpdateJobStatus Status { get; set; }
    }
}
