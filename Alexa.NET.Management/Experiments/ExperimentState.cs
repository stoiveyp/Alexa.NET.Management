using System.Runtime.Serialization;

namespace Alexa.NET.Management.Experiments
{
    public enum ExperimentState
    {
        [EnumMember(Value = "CREATED")]
        Created,
        [EnumMember(Value="ENABLING")]
        Enabling,
        [EnumMember(Value="ENABLED")]
        Enabled,
        [EnumMember(Value="RUNNING")]
        Running,
        [EnumMember(Value="STOPPING")]
        Stopping,
        [EnumMember(Value="STOPPED")]
        Stopped,
        [EnumMember(Value="DELETED")]
        Deleted,
        [EnumMember(Value="FAILED")]
        Failed
    }
}