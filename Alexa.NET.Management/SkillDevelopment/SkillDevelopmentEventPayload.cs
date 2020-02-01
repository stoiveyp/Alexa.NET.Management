using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.SkillDevelopment
{
    public abstract class SkillDevelopmentEventPayload
    {
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public PayloadStatus Status { get; set; }

        [JsonProperty("subscription")]
        public SkillDevelopmentSubscription Subscription { get; set; }

        [JsonProperty("actor")]
        public SkillDevelopmentActor Actor { get; set; }
    }
}