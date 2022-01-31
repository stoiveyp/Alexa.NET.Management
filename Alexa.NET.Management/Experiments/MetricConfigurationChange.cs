using System.Runtime.Serialization;

namespace Alexa.NET.Management.Experiments
{
    public enum MetricConfigurationChange
    {
        [EnumMember(Value="INCREASE")]
        Increase,
        [EnumMember(Value="DECREASE")]
        Decrease
    }
}