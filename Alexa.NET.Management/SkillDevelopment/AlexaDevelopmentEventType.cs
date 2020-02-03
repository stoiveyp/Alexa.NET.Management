using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.SkillDevelopment
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AlexaDevelopmentEventType
    {
        [EnumMember(Value= "AlexaDevelopmentEvent.ManifestUpdate")]
        ManifestUpdate,
        [EnumMember(Value= "AlexaDevelopmentEvent.SkillCertification")]
        SkillCertification,
        [EnumMember(Value= "AlexaDevelopmentEvent.SkillPublish")]
        SkillPublish,
        [EnumMember(Value= "AlexaDevelopmentEvent.InteractionModelUpdate")]
        InteractionModelUpdate
    }
}
