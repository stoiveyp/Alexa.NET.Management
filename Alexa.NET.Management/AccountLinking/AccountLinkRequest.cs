using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.AccountLinking
{
    public class AccountLinkRequest
    {
        [JsonProperty("skipOnEnablement")]
        public bool SkipOnEnablement { get; set; }

        [JsonProperty("type"),JsonConverter(typeof(StringEnumConverter))]
        public AccountLinkType Type { get; set; }

        [JsonProperty("authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("domains")]
        public string[] Domains { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }

        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }

        [JsonProperty("accessTokenUrl")]
        public string AccessTokenUrl { get; set; }

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; }

        [JsonProperty("acessTokenScheme"),JsonConverter(typeof(StringEnumConverter))]
        public AccessTokenScheme AccessTokenScheme { get; set; }
    }
}