using System.Runtime.Serialization;

namespace Alexa.NET.Management.Skills
{
    public enum UnpublishType
    {
        [EnumMember(Value="HIDE")]
        Hide,
        [EnumMember(Value="REMOVE")]
        Remove
    }
}