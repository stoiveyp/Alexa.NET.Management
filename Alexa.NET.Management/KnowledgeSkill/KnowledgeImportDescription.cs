using System.Runtime.Serialization;

namespace Alexa.NET.Management.KnowledgeSkill
{
    public enum KnowledgeImportDescription
    {
        [EnumMember(Value="PENDING")]
        Pending,
        [EnumMember(Value="IN_PROGRESS")]
        InProgress,
        [EnumMember(Value="FAILED")]
        Failed,
        [EnumMember(Value="SUCCEEDED")]
        Succeeded
    }
}