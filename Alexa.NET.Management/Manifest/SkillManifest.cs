using System.Collections.Generic;
using System.Runtime.Serialization;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Internals;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Manifest
{
    public class SkillManifest
    {
        [JsonProperty("publishingInformation", NullValueHandling = NullValueHandling.Ignore)]
        public PublishingInformation PublishingInformation { get; set; }

        [JsonProperty("apis"),JsonConverter(typeof(ApiConverter))]
        public List<Api.IApi> Apis { get; set; }

        [JsonProperty("manifestVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; set; }

        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public Permission[] Permissions { get; set; }

        [JsonProperty("privacyAndCompliance", NullValueHandling = NullValueHandling.Ignore)]
        public PrivacyAndCompliance PrivacyAndCompliance { get; set; }

        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public Events Events { get; set; }
    }

    public class Events
    {
        [JsonProperty("endpoint")]
        public Endpoint Endpoint { get; set; }

        [JsonProperty("publications",NullValueHandling = NullValueHandling.Ignore)]
        public Publication[] Publications { get; set; }

        [JsonProperty("subscriptions", NullValueHandling = NullValueHandling.Ignore)]
        public Subscription[] Subscriptions { get; set; }

        [JsonProperty("regions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, CustomApiRegion> Regions { get; set; }
    }

    public class Publication
    {
        [JsonProperty("eventName"), JsonConverter(typeof(StringEnumConverter))]
        public PublicationEventName Name { get; set; }
    }

    public enum PublicationEventName
    {
        [EnumMember(Value="AMAZON.WeatherAlert.Activated")]
        WeatherAlert,
        [EnumMember(Value = "AMAZON.SportsEvent.Updated")]
        SoccerScoreUpdate,
        [EnumMember(Value = "AMAZON.MessageAlert.Activated")]
        MessageReminder,
        [EnumMember(Value = "AMAZON.OrderStatus.Updated")]
        OrderStatusUpdate,
        [EnumMember(Value = "AMAZON.Occasion.Updated")]
        ReservationConfirmation,
        [EnumMember(Value = "AMAZON.TrashCollectionAlert.Activated")]
        TrashCollectionReminder,
        [EnumMember(Value = "AMAZON.SocialGameInvite.Available")]
        SocialGameInvitation,
        [EnumMember(Value = "AMAZON.MediaContent.Available")]
        MediaContentAvailabilityNotification
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
        SKILL_ACCOUNT_LINKED,
        ITEMS_CREATED,
        ITEMS_UPDATED,
        ITEMS_DELETED,
        SKILL_PROACTIVE_SUBSCRIPTION_CHANGED
    }
}
