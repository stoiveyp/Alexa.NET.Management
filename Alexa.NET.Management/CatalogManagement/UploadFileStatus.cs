using System.Runtime.Serialization;

namespace Alexa.NET.Management.CatalogManagement
{
    public enum UploadFileStatus
    {
        [EnumMember(Value = "PENDING")]
        Pending,
        [EnumMember(Value = "AVAILABLE")]
        Available,
        [EnumMember(Value = "UNAVAILABLE")]
        Unavailable,
        [EnumMember(Value = "PURGED")]
        Purged,
    }
}