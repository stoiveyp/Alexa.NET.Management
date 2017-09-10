using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class AccountLinkUpdate
    {
        [JsonProperty("accountLinkingRequest")]
        public AccountLinkRequest Request { get; set; }
    }
}