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

            var skill1set = skillsets.First(s => s.SkillId == "skill1");
            Assert.NotNull(skill1set.Development);
            Assert.Null(skill1set.Live);

            var skill2set = skillsets.First(s => s.SkillId == "skill2");
            Assert.NotNull(skill2set.Development);
            Assert.NotNull(skill2set.Live);
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
    }
}