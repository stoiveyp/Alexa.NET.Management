using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class CreateSubscriptionRequestEndpoint
    {
        public CreateSubscriptionRequestEndpoint() { }

        public CreateSubscriptionRequestEndpoint(string uri, string authArn)
        {
            Uri = uri;
            Authorization = new CreateSubscriptionRequestEndpointAuthorization(authArn);
        }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("authorization")]
        public CreateSubscriptionRequestEndpointAuthorization Authorization { get; set; }
    }
}