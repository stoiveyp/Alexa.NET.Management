using Newtonsoft.Json;

namespace Alexa.NET.Management.AccountLinking
{
    public class AccountLinkUpdate
    {
        [JsonProperty("accountLinkingRequest")]
        public AccountLinkData Data { get; set; }
    }
}