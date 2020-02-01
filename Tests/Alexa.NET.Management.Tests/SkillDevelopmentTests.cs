using Alexa.NET.Management.SkillDevelopment;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillDevelopmentTests
    {
        [Fact]
        public void SkillUpdateSchema()
        {
            var devEvent = Utility.ExampleFileContent<SkillDevelopmentEvent>("SkillUpdateEvent.json");
            var skillUpdateEvent = Assert.IsType<SkillUpdate>(devEvent);
            Assert.Equal("aaaa-bbbb-cccc-example", skillUpdateEvent.RequestId);
            Assert.Equal(AlexaDevelopmentEventType.ManifestUpdate, skillUpdateEvent.EventName);
            Assert.Equal(skillUpdateEvent.Payload.Status, PayloadStatus.Succeeded);
            Assert.Equal("M123456EXAMPLE", skillUpdateEvent.Payload.Skill.VendorId);
            Assert.True(Utility.CompareJson(skillUpdateEvent, "SkillUpdateEvent.json", "timestamp"));
        }

        [Fact]
        public void InteractionModelUpdateSchema()
        {
            var devEvent = Utility.ExampleFileContent<SkillDevelopmentEvent>("InteractionModelEvent.json");
            var interactionModelEvent = Assert.IsType<InteractionModelUpdate>(devEvent);
            Assert.Equal("aaaa-bbbb-cccc-example", interactionModelEvent.RequestId);
            Assert.Equal(AlexaDevelopmentEventType.InteractionModelUpdate, interactionModelEvent.EventName);
            Assert.Equal(interactionModelEvent.Payload.Status, PayloadStatus.Succeeded);
            Assert.Equal("en-US", interactionModelEvent.Payload.InteractionModel.Locale);
            Assert.True(Utility.CompareJson(interactionModelEvent, "InteractionModelEvent.json","timestamp"));
        }
    }
}
