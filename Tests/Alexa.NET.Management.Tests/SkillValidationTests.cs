using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                Assert.Equal("/v1/skills/skillid/stage/DEVELOPMENT/validations",req.RequestUri.PathAndQuery);
            },new SkillValidationResponse()));
            var response = await management.SkillValidation.Submit("skillid", SkillStage.DEVELOPMENT);
            Assert.NotNull(response);
        }

        [Fact]
        public void ValidationMethodAllowsOptionalLocales()
        {
            var management = new ManagementApi("xxx", new ActionHandler(async req =>
            {
                Assert.Equal(HttpMethod.Post, req.Method);
                Assert.Equal("/v1/skills/skillid/stage/DEVELOPMENT/validations", req.RequestUri.PathAndQuery);
                Assert.NotNull(req.Content);
                var response = JsonConvert.DeserializeObject<SkillValidationRequest>(await req.Content.ReadAsStringAsync());
                Assert.Single(response.Locales);
                Assert.Equal("en-GB", response.Locales.First());
            }, new SkillValidationResponse()));
            var task = management.SkillValidation.Submit("skillid", SkillStage.DEVELOPMENT, SupportedLocales.EnglishUnitedKingdom);
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
        public void ValidationRequestGeneratesCorrectUrl()
        {
            var api = new ManagementApi("xxx",new ActionHandler(req => { Assert.Equal("", req.RequestUri.PathAndQuery); }));
        }
    }
}

