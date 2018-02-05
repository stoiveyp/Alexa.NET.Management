using System.IO;
using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Newtonsoft.Json;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillListConversionTests
    {
        [Fact]
        public void CreatesList()
        {
            var response = GetFromFile<SkillListResponse>("Examples/SkillListResponse.json");
            Assert.Single(response.Skills);
        }

        [Fact]
        public void SkillListDetailsAreCorrect()
        {
            var response = GetFromFile<SkillListResponse>("Examples/SkillListResponse.json");
            var skill = response.Skills.First();
            Assert.Equal("amzn1.ask.skill.6acdbdf8-8420-440e-823e-aaaaaaaabbbb", skill.SkillId);
            Assert.Equal(PublicationStatus.PUBLISHED,skill.Status);
            Assert.Equal(SkillStage.DEVELOPMENT,skill.Stage);
        }

        public JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings());

        private T GetFromFile<T>(string path)
        {
            using (var reader = new JsonTextReader(File.OpenText(path)))
            {
                return Serializer.Deserialize<T>(reader);
            }
        }
    }
}
