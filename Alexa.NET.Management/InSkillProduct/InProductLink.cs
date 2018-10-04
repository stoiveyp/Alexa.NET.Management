using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class InProductLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
