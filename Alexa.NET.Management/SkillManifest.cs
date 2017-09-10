using System.Collections.Generic;
using Alexa.NET.Management.Manifest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management
{
    public class SkillManifest
    {
        [JsonProperty("publishingInformation")]
        public PublishingInformation PublishingInformation { get; set; }

        [JsonProperty("apis")]
        public List<Api.IApi> Apis { get; set; }

        [JsonProperty("manifestVersion")]
        public string Version { get; set; }

        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }

        [JsonProperty("privacyAndCompliance")]
        public PrivacyAndCompliance PrivacyAndCompliance { get; set; }

        [JsonProperty("events")]
        public Events Events { get; set; }
    }

    public class Events
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("subscriptions")]
        public Subscription[] Subscriptions { get; set; }

        [JsonProperty("regions")]
        public Dictionary<string, Endpoint> Regions { get; set; }
    }

    public class Subscription
    {
        [JsonProperty("eventName"), JsonConverter(typeof(StringEnumConverter))]
        public EventName Name { get; set; }
    }

    public enum EventName
    {
        SKILL_ENABLED,
        SKILL_DISABLED,
        SKILL_PERMISSION_ACCEPTED,
        SKILL_PERMISSION_CHANGED,
        SKILL_ACCOUNT_LINKED
    }
}
