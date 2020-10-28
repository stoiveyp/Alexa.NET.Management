using System.Runtime.Serialization;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public enum CatalogResourceType
    {
        [EnumMember(Value="Catalog")]
        Catalog,
        [EnumMember(Value="SlotType")]
        SlotType,
        [EnumMember(Value="InterationModel")]
        InterationModel
    }
}