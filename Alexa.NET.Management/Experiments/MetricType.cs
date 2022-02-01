using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.Experiments
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MetricType
    {
        [EnumMember(Value="KEY")]
        Key,
        [EnumMember(Value="GUARDRAIL")]
        Guardrail
    }
}