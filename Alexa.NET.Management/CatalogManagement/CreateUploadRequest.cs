using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.CatalogManagement
{
    public class CreateUploadRequest
    {
        [JsonProperty("numberOfUploadParts")]
        public int NumberOfUploadParts { get; set; }
    }
}
