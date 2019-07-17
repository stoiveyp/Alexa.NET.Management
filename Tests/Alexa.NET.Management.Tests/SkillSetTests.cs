using System;
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

            var skillsets = SkillSet.From(null,skill2dev, skill1, skill2live).ToArray();
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
            var skillSet = SkillSet.From(null,skill1).First();
            Assert.Equal("british",skillSet.Name);
        }

        [Fact]
        public void PreferredLocaleReturnsValue()
        {
            var skillSet = GetSkillSet(SkillStage.Development,"en-GB");
            Assert.Equal("british", skillSet.Name);
        }

        [Fact]
        public void EmptyContextHandlesSummary()
        {
            var context = SkillSetStage.Empty();
            Assert.Equal(string.Empty,context.ID);
            Assert.Equal(string.Empty,context.Name);
            Assert.False(context.Stage.HasValue);
        }

        [Fact]
        public void ContextHandlesSummary()
        {
            var skillSet = GetSkillSet(SkillStage.Development,"en-GB");
            Assert.Equal("british",skillSet.CurrentStage.Name);
            Assert.Equal("skill1", skillSet.CurrentStage.ID);
            Assert.Equal(SkillStage.Development,skillSet.CurrentStage.Stage);
        }

        [Fact]
        public void ContextHandlesLocales()
        {
            var skillSet = GetSkillSet(SkillStage.Development, "en-GB");
            Assert.Equal(2, skillSet.CurrentStage.Locales.Length);
        }

        [Fact]
        public void SimulationApiSupportsDevelopment()
        {
            var locale = GetSkillSetLocale("en-GB");
            Assert.True(locale.Api.SimulationSupported);
            Assert.NotNull(locale.Api.Simulation);
        }

        [Fact]
        public void SimulationApiDoesntSupportsDevelopment()
        {
            var locale = GetSkillSetLocale("en-GB",SkillStage.Live);
            Assert.False(locale.Api.SimulationSupported);
            Assert.Throws<InvalidStageException>(() => locale.Api.Simulation);
        }

        [Fact]
        public void VerifyLocaleComparer()
        {
            var options = new SkillSetOptions("en-GB","en-US","de-DE");
            var unordered = new[] {"en-IN","de-DE", "en-AU", "en-GB", "en-US"};
            var ordered = unordered.OrderBy(l => l,options).ToArray();
            Assert.Equal("en-GB",ordered[0]);
            Assert.Equal("en-US", ordered[1]);
            Assert.Equal("de-DE", ordered[2]);
            Assert.Equal("en-AU", ordered[3]);
            Assert.Equal("en-IN", ordered[4]);
        }




        private SkillSet GetSkillSet(SkillStage stage, string preferredLocale)
        {
            var skill1 = new SkillSummary
            {
                SkillId = "skill1",
                Stage = stage,
                NameByLocale = new Dictionary<string, string>
                {
                    {"de-DE","german"},
                    {"en-GB","british"}
                }
            };
            return SkillSet.From(null, new SkillSetOptions(preferredLocale), skill1).First();
        }

        private SkillSetLocale GetSkillSetLocale(string locale, SkillStage stage = SkillStage.Development)
        {
            return GetSkillSet(stage,locale).CurrentStage.Locales.First();
        }
    }
}