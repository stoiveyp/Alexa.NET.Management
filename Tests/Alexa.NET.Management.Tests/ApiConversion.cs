using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Alexa.NET.Management.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Alexa.NET.Management.Tests
{
    public class ApiConversion
    {
        private ITestOutputHelper Output { get; }

        public ApiConversion(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void TestApiConversionSerialize()
        {
            var converter = new ApiConverter(Output.WriteLine);
            var settings = new JsonSerializerSettings { Converters = new List<JsonConverter>(new[] { converter }) };
            var serializer = JsonSerializer.Create(settings);

            var list = new List<IApi> {new FlashBriefingApi(), new HouseholdListApi()};
            var source = JObject.FromObject(list, serializer);

            var target = new JObject { { "flashBriefing", JObject.FromObject(new FlashBriefingApi())}, { "householdList", JObject.FromObject(new HouseholdListApi()) } };
            Output.WriteLine(source.ToString(Formatting.None));
            Assert.True(JObject.DeepEquals(source,target));
        }

        [Fact]
        public void TestApiConversionDeserialize()
        {
            var converter = new ApiConverter(Output.WriteLine);
            var settings = new JsonSerializerSettings {Converters = new List<JsonConverter>(new[]{converter})};
            var serializer = JsonSerializer.Create(settings);
            var json = new JObject {{"flashBriefing",new JObject() }, { "householdList", new JObject() } };
            using (var obj = new JsonTextReader(new StringReader(json.ToString(Formatting.None))))
            {
                var res = serializer.Deserialize<List<IApi>>(obj);
                Assert.Equal(res.Count, 2);
                Assert.IsType<FlashBriefingApi>(res.First());
                Assert.IsType<HouseholdListApi>(res.Skip(1).First());
            }
        }
    }
}
