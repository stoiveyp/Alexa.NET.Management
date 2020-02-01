using System.Runtime.Serialization;

namespace Alexa.NET.Management.SkillDevelopment
{
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
