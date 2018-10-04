using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class PriceListing
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
    }
}