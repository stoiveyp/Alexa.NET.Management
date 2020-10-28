using System.Runtime.Serialization;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public enum UpdateJobStatus
    {
        [EnumMember(Value="ENABLED")]
        Enabled,
        [EnumMember(Value="DISABLED")]
        Disabled
    }
}