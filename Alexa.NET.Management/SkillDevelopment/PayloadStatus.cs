using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Alexa.NET.Management.SkillDevelopment
{
    public enum PayloadStatus
    {
        [EnumMember(Value="SUCCEEDED")]
        Succeeded,
        [EnumMember(Value = "FAILED")]
        Failed
    }
}
