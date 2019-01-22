using System.Runtime.Serialization;

namespace Alexa.NET.Management.InteractionModel
{
    public enum IntentDelegationStrategy
    {
        [EnumMember(Value="ALWAYS")]
        Always,
        [EnumMember(Value="SKILL_RESPONSE")]
        SkillResponse
    }
}