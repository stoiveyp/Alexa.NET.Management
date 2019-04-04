using System.Runtime.Serialization;

namespace Alexa.NET.Management
{
    public enum SortDirection
    {
        [EnumMember(Value ="asc")]
        Ascending,
        [EnumMember(Value="desc")]
        Descending
    }
}