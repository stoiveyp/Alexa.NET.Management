using Newtonsoft.Json;

namespace Alexa.NET.Management.InSkillProduct
{
    public class PricingSummary
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("primeMemberPrice")]
        public decimal PrimePrice { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
    }
}