using Newtonsoft.Json;

namespace Alexa.NET.Management.AccountLinking
{
    public class AccountLinkInformation
    {
        [JsonProperty("accountLinkingResponse")]
        public AccountLinkData Response { get; set; }
    }
}