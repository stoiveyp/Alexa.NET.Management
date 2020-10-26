using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.ReferenceCatalogManagement
{
    public class UpdateJobConverter : JsonConverter<IUpdateJobDefinition>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, IUpdateJobDefinition value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override IUpdateJobDefinition ReadJson(JsonReader reader, Type objectType, IUpdateJobDefinition existingValue,
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

        public static Dictionary<string, Func<IUpdateJobDefinition>> InterfaceLookup { get; set; } =
            new Dictionary<string, Func<IUpdateJobDefinition>>
            {
                {"CatalogAutoRefresh", () => new CatalogAutoRefreshJob()},
                {"ReferenceVersionUpdate", () => new ReferenceVersionUpdateJob()}
            };

        private IUpdateJobDefinition Mappings(string value)
        {
            if (InterfaceLookup.ContainsKey(value))
            {
                return InterfaceLookup[value]();
            }

            return null;
        }
    }
}
