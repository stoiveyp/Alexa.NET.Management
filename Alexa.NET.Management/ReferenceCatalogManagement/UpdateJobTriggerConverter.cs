using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class UpdateJobTriggerConverter : JsonConverter<IUpdateJobTrigger>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, IUpdateJobTrigger value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IUpdateJobTrigger ReadJson(JsonReader reader, Type objectType, IUpdateJobTrigger existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var target = Mappings(jObject["type"].Value<string>());

            if (target != null)
            {
                serializer.Populate(jObject.CreateReader(), target);
            }

            return target;
        }

        public static Dictionary<string, Func<IUpdateJobTrigger>> InterfaceLookup { get; set; } =
            new Dictionary<string, Func<IUpdateJobTrigger>>
            {
                {"Schedule", () => new CatalogScheduleTrigger()},
                {"ReferencedResourceJobsComplete", () => new ReferencedResourceJobsCompleteTrigger()}
            };

        private IUpdateJobTrigger Mappings(string value)
        {
            if (InterfaceLookup.ContainsKey(value))
            {
                return InterfaceLookup[value]();
            }

            return null;
        }
    }
}
