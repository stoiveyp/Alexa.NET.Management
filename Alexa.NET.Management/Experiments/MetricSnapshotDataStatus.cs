using System.Runtime.Serialization;

namespace Alexa.NET.Management.Experiments
{
    public enum MetricSnapshotDataStatus
    {
        [EnumMember(Value="RELIABLE")]
        Reliable,
        [EnumMember(Value="UNRELIABLE")]
        Unreliable
    }
}