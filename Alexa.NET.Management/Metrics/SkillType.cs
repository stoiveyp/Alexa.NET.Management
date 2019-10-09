using System.Runtime.Serialization;

namespace Alexa.NET.Management.Metrics
{
    public enum SkillType
    {
        [EnumMember(Value="custom")]
        Custom,
        [EnumMember(Value = "smartHome")]
        SmartHome,
        [EnumMember(Value = "flashBriefing")]
        FlashBriefing
    }
}