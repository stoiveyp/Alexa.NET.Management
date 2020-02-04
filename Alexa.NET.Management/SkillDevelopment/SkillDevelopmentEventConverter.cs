using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.SkillDevelopment
{
    public class SkillDevelopmentEventConverter:JsonConverter<SkillDevelopmentEvent>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, SkillDevelopmentEvent value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override SkillDevelopmentEvent ReadJson(JsonReader reader, Type objectType, SkillDevelopmentEvent existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            if(!jObject.ContainsKey("payload") || jObject["payload"].Value<JObject>() == null)
            {
                throw new InvalidOperationException("SkillDevelopmentEvent type requires a payload object");
            }

            var target = jObject.Value<JObject>("payload").ContainsKey("skill") ? (SkillDevelopmentEvent)new SkillUpdate() : new InteractionModelUpdate();
            
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
