using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class TaxInformation
    {
        [JsonProperty("category")]
        public string Category { get; set; }
    }
}