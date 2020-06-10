using System.Runtime.Serialization;

namespace Alexa.NET.Management.Asr.Evaluations
{
    public enum EvaluationStatusState
    {
        [EnumMember(Value="COMPLETED")]
        Completed,
        [EnumMember(Value="IN_PROGRESS")]
        InProgress,
        [EnumMember(Value="FAILED")]
        Failed
    }
}