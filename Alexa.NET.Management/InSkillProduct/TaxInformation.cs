using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class TaxInformation
    {
        public TaxInformation() { }

        public TaxInformation(string category)
        {
            Category = category;
        }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}