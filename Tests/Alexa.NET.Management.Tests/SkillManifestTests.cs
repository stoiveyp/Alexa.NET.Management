using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.InteractionModel.ValidationRules;
using Alexa.NET.Management.Internals;
using Alexa.NET.Management.Manifest;
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
            var manifest = Utility.ExampleFileContent<Skill>("CustomSkillManifest.json").Manifest;
            Assert.Equal(manifest.Apis.Count,1);

            var customApi = manifest.Apis.First() as CustomApi;
            Assert.NotNull(customApi);
            Assert.Equal(customApi.Endpoint.Uri,GlobalCustomEndpoint);
            Assert.Equal(SslCertificateType.Trusted,customApi.Regions["NA"].Endpoint.SslCertificateType);
            Assert.Equal("arn:aws:lambda:us-east-1:040623927470:function:sampleSkill",manifest.Events.Regions.First().Value.Endpoint.Uri);
            var task = Assert.Single(customApi.Tasks);
            Assert.Equal("AMAZON.PrintPDF",task.Name);
        }

        [Fact]
        public void GadgetSupportDeserializesCorrectly()
        {
            var support = Utility.ExampleFileContent<GadgetSupport>("GadgetSupport.json");

            Assert.Equal(GadgetRequirement.Required,support.Requirement);
            Assert.Equal(1,support.MinPlayers);
            Assert.Equal(3,support.MaxPlayers);
            Assert.Equal(4,support.MinButtons);
        }

        [Fact]
        public void InteractionModelDeserializesCorrectly()
        {
            var model = Utility.ExampleFileContent<SkillInteractionContainer>("InteractionModel.json");
            var slotType = model.InteractionModel.Language.SlotTypes.First(st => st.Name == "TechNottsEvent");
            Assert.Equal("tech-nottingham",slotType.Values.First().Id);

            var dialogIntent = model.InteractionModel.Dialog.Intents.First();
            Assert.Equal(dialogIntent.Name, "NextSpecificEvent");
            Assert.Equal(true,dialogIntent.ConfirmationRequired);
            var firstSlot = dialogIntent.Slots.First();
            Assert.IsType<HasEntityResolutionMatch>(firstSlot.Validations.Skip(1).First());
            Assert.IsType<IsNotInSet>(firstSlot.Validations.First());
        }

        [Fact]
        public async Task VersionsWorksAsExpected()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillid/stages/development/interactionModel/locales/en-GB/versions?sortDirection=asc&nextToken=wibble&maxResults=10", req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new StringContent(Utility.ExampleFileContent("InteractionModelVersions.json"));
                return Task.FromResult(message);
            }));
            var response =
                await management.InteractionModel.Versions("skillid", "en-GB", SortDirection.Ascending, "wibble", 10);
            Assert.NotNull(response);
            Assert.Equal(2,response.SkillModelVersionsSummary.Length);
            var summary = response.SkillModelVersionsSummary.First();
            Assert.Equal(summary.Version,"2");
            Assert.Equal(DateTime.Parse("2019-04-04T07:45:13.495Z").ToUniversalTime(), summary.CreationTime);
            var link = Assert.Single(summary.Links);
            Assert.Equal("self",link.Key);
            Assert.Equal(
                "/v1/skills/amzn1.ask.skill.c694ef3e-f0b2-41e7-aab2-000000000000/stages/development/interactionModel/locales/en_GB/versions/2",
                link.Value.Href);
        }

        [Fact]
        public async Task VersionWorksAsExpected()
        {
            var management = new ManagementApi("xxx", new ActionHandler(req =>
            {
                Assert.Equal(HttpMethod.Get, req.Method);
                Assert.Equal("/v1/skills/skillid/stages/development/interactionModel/locales/en-GB/versions/2",req.RequestUri.PathAndQuery);

                var message = new HttpResponseMessage(HttpStatusCode.OK);
                message.Content = new StringContent(Utility.ExampleFileContent("InteractionModelVersion.json"));
                return Task.FromResult(message);
            }));
            var response =
                await management.InteractionModel.Version("skillid", "en-GB","2");
            Assert.NotNull(response);
            Assert.Equal("2", response.Version);
            Assert.NotNull(response.InteractionModel);
        }
    }
}
