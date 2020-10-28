using Newtonsoft.Json;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class LocaleCatalogResource : CatalogResource
    {
        [JsonProperty("locales",NullValueHandling = NullValueHandling.Ignore)]
        public string[] Locales  { get; set; }
    }
}