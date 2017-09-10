using System.Collections.Generic;
using System.IO;
using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillManifestTests
    {
        private const string GlobalCustomEndpoint = "arn:aws:lambda:us-east-1:040623927470:function:sampleSkill";

        public JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new ApiConverter() }
        });

        [Fact]
        public void TestCustomSkillManifest()
        {
            var manifest = GetFromFile<Skill>("Examples/CustomSkillManifest.json").Manifest;
            Assert.Equal(manifest.Apis.Count,1);

            var customApi = manifest.Apis.First() as CustomApi;
            Assert.NotNull(customApi);
            Assert.Equal(customApi.Endpoint.Uri,GlobalCustomEndpoint);
        }

        private T GetFromFile<T>(string path)
        {
            using (var reader = new JsonTextReader(File.OpenText(path)))
            {
                return Serializer.Deserialize<T>(reader);
            }
        }
    }
}
