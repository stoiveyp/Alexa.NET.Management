using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class CreateInSkillProductResponse
    {
        [JsonProperty("productId")]
        public string ProductId { get; set; }
    }
}
