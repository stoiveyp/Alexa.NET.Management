using System.Runtime.Serialization;

namespace Alexa.NET.Management.Skills
{
    public enum PublicationStatus
    {
        [EnumMember(Value="DEVELOPMENT")]
        Development,
        [EnumMember(Value = "CERTIFICATION")]
        Certification,
        [EnumMember(Value = "PUBLISHED")]
        Published,
        [EnumMember(Value = "SUPPRESSED")]
        Suppressed,
        [EnumMember(Value = "PULLED")]
        Pulled,
        [EnumMember(Value = "HIDDEN")]
        Hidden,
        [EnumMember(Value = "REMOVED")]
        Removed
    }
}