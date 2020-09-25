using System;
using System.Collections.Generic;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexa.NET.Management.Internals
{
    public class CustomApiInterfaceConverter : JsonConverter<CustomApiInterface>
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, CustomApiInterface value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override CustomApiInterface ReadJson(JsonReader reader, Type objectType, CustomApiInterface existingValue,
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

        public static Dictionary<string, Func<CustomApiInterface>> InterfaceLookup { get; set; } =
            new Dictionary<string, Func<CustomApiInterface>>
            {
                {"ALEXA_EXTENSION", () => new ExtensionInterface()}
            };

        private CustomApiInterface Mappings(string value)
        {
            if (InterfaceLookup.ContainsKey(value))
            {
                return InterfaceLookup[value]();
            }

            return null;
        }
    }
}
