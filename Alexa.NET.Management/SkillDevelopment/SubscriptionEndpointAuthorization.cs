using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SubscriptionEndpointAuthorization
    {
        public SubscriptionEndpointAuthorization(string arn)
        {
            ARN = arn;
        }

        [JsonProperty("type")] public string Type => "AWS_IAM";

        [JsonProperty("arn")]
        public string ARN { get; set; }
    }
}