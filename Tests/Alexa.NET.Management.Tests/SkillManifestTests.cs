using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}
