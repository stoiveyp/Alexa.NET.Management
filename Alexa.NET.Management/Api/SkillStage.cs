using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Alexa.NET.Management.Api
{
    public enum SkillStage
    {
        [EnumMember(Value="development")]
        development,
        [EnumMember(Value="live")]
        live
    }
}
