using System.Runtime.Serialization;

namespace Alexa.NET.Management.Skills
{
    public enum UnpublishReason
    {
        [EnumMember(Value="Changing invocation name")]
        ChangingInvocationName,
        [EnumMember(Value="Published by mistake")]
        PublishedByMistake,
        [EnumMember(Value="It takes time to maintain my skill")]
        TimeToMaintain,
        [EnumMember(Value="My infrastructure costs are too high")]
        InfrastructureCosts,
        [EnumMember(Value="Technical Issues")]
        TechnicalIssues,
        [EnumMember(Value="Other")]
        Other
    }
}