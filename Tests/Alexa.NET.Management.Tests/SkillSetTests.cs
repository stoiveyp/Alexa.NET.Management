using System.Collections.Generic;
using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Alexa.NET.Management.SkillSets;
using Xunit;

namespace Alexa.NET.Management.Tests
{
    public class SkillSetTests
    {
        [Fact]
        public void CreatesFromSummaryCorrectly()
        {
            var skill1 = new SkillSummary { SkillId = "skill1", Stage = SkillStage.Development };
            var skill2dev = new SkillSummary { SkillId = "skill2", Stage = SkillStage.Development };
            var skill2live = new SkillSummary { SkillId = "skill2", Stage = SkillStage.Live };

            var skillsets = SkillSet.From(skill2dev, skill1, skill2live).ToArray();
            Assert.Equal(2, skillsets.Length);

            var skill1set = skillsets.First(s => s.ID == "skill1");
            Assert.Equal(SkillStage.Development,skill1set.Development.Stage);
            Assert.Null(skill1set.Live.Stage);

            var skill2set = skillsets.First(s => s.ID == "skill2");
            Assert.Equal(SkillStage.Development,skill2set.Development.Stage);
            Assert.Equal(SkillStage.Live,skill2set.Live.Stage);
        }

        [Fact]
        public void MissingPreferredNameReturnsFirstName()
        {
            var skill1 = new SkillSummary
            {
                SkillId = "skill1",
                Stage = SkillStage.Development,
                NameByLocale = new Dictionary<string, string>
                {
                    {"en-GB","british"},
                    {"de-DE","german"}
                }
            };
            var skillSet = SkillSet.From(skill1).First();
            Assert.Equal("british",skillSet.Name);
        }

        [Fact]
        public void PreferredLocaleReturnsValue()
        {
            var skill1 = new SkillSummary
            {
                SkillId = "skill1",
                Stage = SkillStage.Development,
                NameByLocale = new Dictionary<string, string>
                {
                    {"de-DE","german"},
                    {"en-GB","british"}
                }
            };
            var skillSet = SkillSet.From(new SkillSetOptions("en-GB"),skill1).First();
            Assert.Equal("british", skillSet.Name);
        }

        [Fact]
        public void EmptyContextHandlesSummary()
        {
            var context = SkillSetContext.Empty();
            Assert.Equal(string.Empty,context.ID);
            Assert.Equal(string.Empty,context.Name);
            Assert.False(context.Stage.HasValue);
        }

        [Fact]
        public void ContextHandlesSummary()
        {
            var skill1 = new SkillSummary
            {
                SkillId = "skill1",
                Stage = SkillStage.Development,
                NameByLocale = new Dictionary<string, string>
                {
                    {"de-DE","german"},
                    {"en-GB","british"}
                }
            };
            var skillSet = SkillSet.From(new SkillSetOptions("en-GB"), skill1).First();
            Assert.Equal("british",skillSet.CurrentContext.Name);
            Assert.Equal("skill1", skillSet.CurrentContext.ID);
            Assert.Equal(SkillStage.Development,skillSet.CurrentContext.Stage);
        }
    }
}