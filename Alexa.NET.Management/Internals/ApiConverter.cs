using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;

namespace Alexa.NET.Management.Internals
{
    public class ApiConverter:JsonConverter
    {
        private static readonly Dictionary<String, Type> DefaultMapping = new Dictionary<string, Type>
        {
            {"custom", typeof(CustomApi)},
            {"flashBriefing", typeof(FlashBriefingApi)},
            {"video", typeof(VideoApi)},
            {"smartHome", typeof(SmartHomeApi)},
            {"householdList", typeof(HouseholdListApi)}
        };

        private readonly Dictionary<string, Type> Mapping;

        public ApiConverter() : this(DefaultMapping){}

        public ApiConverter(Dictionary<string, Type> mapping)
        {
            Mapping = (mapping ?? new Dictionary<string, Type>());
            foreach (var kvp in DefaultMapping)
            {
                Mapping.Add(kvp.Key,kvp.Value);
            }
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var item in (List<IApi>) value)
            {
                var keyType = item.GetType();
                var pair = Mapping.First(kvp => kvp.Value == keyType);
                writer.WritePropertyName(pair.Key);
                serializer.Serialize(writer,item);
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = new List<IApi>();
            while (reader.Read() && reader.Value != null)
            {
                var pair = Mapping[reader.Value.ToString()];
                reader.Read();
                list.Add((IApi)serializer.Deserialize(reader,pair));
            }

            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<IApi>);
        }
    }
}