using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class ApiLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
