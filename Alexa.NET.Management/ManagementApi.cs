using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;

namespace Alexa.NET.Management
{
    public class ManagementApi
    {
        private const string V0BaseAddress = "https://api.amazonalexa.com/v0";

        public ManagementApi(string token) : this(new Uri(V0BaseAddress,UriKind.Absolute), token)
        {

        }

        public ManagementApi(Func<Task<string>> getToken) : this(new Uri(V0BaseAddress,UriKind.Absolute), getToken)
        {

        }

        public ManagementApi(Uri baseAddress, string token) : this(baseAddress, () => Task.FromResult(token))
        {
        }

        public ManagementApi(Uri baseAddress, Func<Task<string>> getToken)
        {
            Skills = RestService.For<ISkillManagementApi>(
                baseAddress.ToString(),
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = getToken,
                    JsonSerializerSettings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter>(new[]{new ApiConverter(null)})
                    }
                });
        }

        public ISkillManagementApi Skills {
            get;
            set;
        }
    }

    public class ApiConverter:JsonConverter
    {
        private readonly Dictionary<string, Type> Mapping;

        public ApiConverter() : this(new Dictionary<string, Type>
        {
            {"custom", typeof(CustomApi)},
            {"flashBriefing", typeof(FlashBriefingApi)},
            {"video", typeof(VideoApi)},
            {"smartHome", typeof(SmartHomeApi)},
            {"householdList", typeof(HouseholdListApi)}
        }){}

        public ApiConverter(Dictionary<string, Type> mapping)
        {
            Mapping = mapping;
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
