using Newtonsoft.Json;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class CreateSubscriptionRequestEndpointAuthorization
    {
        public CreateSubscriptionRequestEndpointAuthorization(string arn)
        {
            ARN = arn;
        }

        [JsonProperty("type")] public string Type => "AWS_IAM";

        [JsonProperty("arn")]
        public string ARN { get; set; }
    }
}