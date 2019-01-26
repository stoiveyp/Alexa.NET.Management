using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillValidationTests
    {
        [Fact]
        public async Task ValidationMethodWorks()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post,req.Method);
                Assert.Equal("/v1/skills/skillid/stage/development/validations",req.RequestUri.PathAndQuery);
            },new SkillValidationResponse()));
            var response = await management.SkillValidation.Submit("skillid", SkillStage.DEVELOPMENT);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ValidationMethodAllowsOptionalLocales()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillid/stage/development/validations", req.RequestUri.PathAndQuery);
                Assert.NotNull(req.Content);
                var response = JsonConvert.DeserializeObject<SkillValidationRequest>(await req.Content.ReadAsStringAsync());
                Assert.Single(response.Locales);
                Assert.Equal("en-GB", response.Locales.First());
            }, new SkillValidationResponse()));
            var task = await management.SkillValidation.Submit("skillid", SkillStage.DEVELOPMENT, SupportedLocales.EnglishUnitedKingdom);
            Assert.NotNull(task);
        }

        [Fact]
        public void ValidationRequestGeneratesCorrectBody()
        {
            var expected = new JObject(new JProperty("locales", new JArray("en-GB")));
            var request = JObject.FromObject(new SkillValidationRequest {Locales = new[] {"en-GB"}});
            Assert.True(JToken.DeepEquals(expected, request));
        }

        [Fact]
        public async Task ValidationResponseDeserializesCorrectly()
        {
            var api = new ManagementApi("xxx",new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Post,req.Method);
                Assert.Equal("/v1/skills/skillid/stage/development/validations", req.RequestUri.PathAndQuery);
            },JsonConvert.DeserializeObject<SkillValidationResponse>(File.ReadAllText("Examples/InProgressValidation.json"))));
            var task = await api.SkillValidation.Submit("skillid", SkillStage.DEVELOPMENT);
            Assert.Equal("33333333-3333-3333-3333-333333333333", task.Id);
            Assert.Equal(ValidationStatus.IN_PROGRESS,task.Status);
            Assert.Null(task.Result);
        }

        [Fact]
        public async Task GetValidationResponseGeneratesUrl()
        {
            var api = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get,req.Method);
                Assert.Equal("/v1/skills/skillid/stages/development/validations/validationid",req.RequestUri.PathAndQuery);
            },new SkillValidationResponse()));
            var task = await api.SkillValidation.Get("skillid",SkillStage.DEVELOPMENT,"validationid");
            Assert.NotNull(task);
        }

        [Fact]
        public async Task ValidationResponseDeserializes()
        {
            var api = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillid/stages/development/validations/validationid", req.RequestUri.PathAndQuery);
            }, GetFromFile<SkillValidationResponse>("Examples/ValidationResult.json")));
            var task = await api.SkillValidation.Get("skillid", SkillStage.DEVELOPMENT, "validationid");
            
            Assert.Equal("11111111-1111-1111-1111-111111111111",task.Id);
            Assert.Equal(ValidationStatus.SUCCESSFUL,task.Status);
            Assert.NotNull(task.Result);
            Assert.Null(task.Result.Error);
            Assert.NotNull(task.Result.Validations);

            Assert.Equal(18,task.Result.Validations.Length);
        }

        private readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings());

        private T GetFromFile<T>(string path)
        {
            using (var reader = new JsonTextReader(File.OpenText(path)))
            {
                return Serializer.Deserialize<T>(reader);
            }
        }
    }
}

