using System.Runtime.Serialization;

namespace Alexa.NET.Management.CatalogManagement
{
    public enum IngestionStepStatus
    {
        [EnumMember(Value = "PENDING")]
        Pending,
        [EnumMember(Value = "SUCCEEDED")]
        Succeeded,
        [EnumMember(Value = "FAILED")]
        Failed,
        [EnumMember(Value = "CANCELLED")]
        Cancelled
    }
}