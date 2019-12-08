using System.Runtime.Serialization;

namespace Alexa.NET.Management.Skills
{
    public enum PublishStatus
    {
        [EnumMember(Value = "IN_PROGRESS")]
        InProgress,
        [EnumMember(Value = "SUCCEEDED")]
        Succeeded,
        [EnumMember(Value = "FAILED")]
        Failed,
        [EnumMember(Value = "CANCELLED")]
        Cancelled,
        [EnumMember(Value = "SCHEDULED")]
        Scheduled
    }
}