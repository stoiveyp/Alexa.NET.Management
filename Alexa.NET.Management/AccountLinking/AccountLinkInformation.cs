using Newtonsoft.Json;

namespace Alexa.NET.Management
{
    public class AccountLinkInformation
    {
        [JsonProperty("accountLinkingResponse")]
        public AccountLinkResponse Response { get; set; }
    }
}