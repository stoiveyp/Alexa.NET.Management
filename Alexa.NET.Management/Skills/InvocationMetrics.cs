using Newtonsoft.Json;

namespace Alexa.NET.Management.Skills
{
    public class InvocationMetrics
    {
        [JsonProperty("skillExecutionTimeInMilliseconds")]
        public int ExecutionTime { get; set; }
    }
}