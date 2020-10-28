using System.Runtime.Serialization;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public enum UpdateJobExecutionStatus
    {
        [EnumMember(Value="SUCCESS")]
        Success,
        [EnumMember(Value="FAILURE")]
        Failure,
        [EnumMember(Value="IN_PROGRESS")]
        InProgress,
        [EnumMember(Value="SCHEDULED")]
        Scheduled
    }
}