using System.Runtime.Serialization;

namespace Alexa.NET.Management.Experiments
{
    public enum ExperimentUpdateState
    {
        [EnumMember(Value = "ENABLED")]
        Enabled,
        [EnumMember(Value = "RUNNING")]
        Running,
        [EnumMember(Value = "STOPPED")]
        Stopped
    }
}