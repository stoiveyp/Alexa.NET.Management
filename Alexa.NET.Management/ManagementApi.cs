using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
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
        private Action<string> Logger { get; }

        public ApiConverter(Action<string> logger)
        {
            Logger = logger;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            foreach (var item in (List<IApi>) value)
            {
                switch (item)
                {
                    case FlashBriefingApi flash:
                        writer.WritePropertyName("flashBriefing");
                        serializer.Serialize(writer,flash);
                        break;
                    case HouseholdListApi house:
                        writer.WritePropertyName("householdList");
                        serializer.Serialize(writer,house);
                        break;
                }
            }
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = new List<IApi>();
            while (reader.Read())
            {
                Logger(reader.TokenType.ToString());
                Logger(reader.Path);
                reader.Read();
                switch (reader.Path)
                {
                    case "custom":
                        list.Add(serializer.Deserialize<CustomApi>(reader));
                        break;
                    case "flashBriefing":
                        list.Add(serializer.Deserialize<FlashBriefingApi>(reader));
                        break;
                    case "video":
                        list.Add(serializer.Deserialize<VideoApi>(reader));
                        break;
                    case "smartHome":
                        list.Add(serializer.Deserialize<SmartHomeApi>(reader));
                        break;
                    case "householdList":
                        list.Add(serializer.Deserialize<HouseholdListApi>(reader));
                        break;
                }
            }

            Logger(reader.TokenType.ToString());
            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<IApi>);
        }
    }
}
