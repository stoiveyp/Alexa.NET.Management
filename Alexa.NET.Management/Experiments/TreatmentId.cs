using System.Runtime.Serialization;

namespace Alexa.NET.Management.Experiments
{
    public enum TreatmentId
    {
        [EnumMember(Value="C")]
        Control,
        [EnumMember(Value="T1")]
        Treatment
    }
}