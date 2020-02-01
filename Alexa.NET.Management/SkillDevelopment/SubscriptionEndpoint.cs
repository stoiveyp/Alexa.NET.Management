using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SubscriptionEndpoint
    {
        public SubscriptionEndpoint() { }

        public SubscriptionEndpoint(string uri, string authArn)
        {
            Uri = uri;
            Authorization = new SubscriptionEndpointAuthorization(authArn);
        }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("authorization")]
        public SubscriptionEndpointAuthorization Authorization { get; set; }
    }
}