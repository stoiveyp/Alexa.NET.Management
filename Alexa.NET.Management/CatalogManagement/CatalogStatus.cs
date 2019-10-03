using System.Runtime.Serialization;

namespace Alexa.NET.Management.CatalogManagement
{
    public enum CatalogStatus
    {
        [EnumMember(Value="PENDING")]
        Pending,
        [EnumMember(Value = "PROCESSING")]
        Processing,
        [EnumMember(Value = "FAILED")]
        Failed,
        [EnumMember(Value = "SUCCESS")]
        Success,
    }
}