using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Alexa.NET.Management.Metrics
{
    public enum MetricPeriod
    {
        [EnumMember(Value="SINGLE")]
        Single,
        [EnumMember(Value = "PT15M")]
        FifteenMinutes,
        [EnumMember(Value = "PT1H")]
        OneHour,
        [EnumMember(Value = "P1D")]
        OneDay

    }
}
