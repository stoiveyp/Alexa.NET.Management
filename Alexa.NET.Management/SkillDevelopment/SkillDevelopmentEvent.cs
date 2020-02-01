using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Alexa.NET.Management.SkillDevelopment
{
    [JsonConverter(typeof(SkillDevelopmentEventConverter))]
    public abstract class SkillDevelopmentEvent
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime DateTime { get; set; }

        [JsonProperty("eventName"),JsonConverter(typeof(StringEnumConverter))]
        public AlexaDevelopmentEventType EventName { get; set; }
    }

    public abstract class SkillDevelopmentEvent<T>:SkillDevelopmentEvent where T:SkillDevelopmentEventPayload
    {
        [JsonProperty("payload")]
        public T Payload { get; set; }
    }
}
