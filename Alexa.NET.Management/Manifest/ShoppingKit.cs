using Newtonsoft.Json;

namespace Alexa.NET.Management.Manifest
{
    public class ShoppingKit
    {
        [JsonProperty("isShoppingActionsEnabled")]
        public bool IsShoppingActionsEnabled { get; set; }
    }
}