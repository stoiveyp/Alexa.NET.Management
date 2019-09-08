using System.Runtime.Serialization;

namespace Alexa.NET.Management.Nlu.Evaluation
{
    public enum TestCaseStatus
    {
        [EnumMember(Value = "PASSED")]
        Passed,
        [EnumMember(Value = "FAILED")]
        Failed
    }
}