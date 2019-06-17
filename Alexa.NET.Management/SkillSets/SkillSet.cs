using System;
using System.Collections.Generic;
using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSet:ISkillSetSummary
    {
        public ISkillSetContext Development { get; }
        public ISkillSetContext Live { get; }

        public SkillSetOptions Options { get; }

        public string ID => CurrentContext.ID;

        public string Name => CurrentContext.Name;

        public SkillStage? Stage { get; private set; }

        public void SetCurrentStage(SkillStage stage)
        {
            Stage = stage;
        }

        public ISkillSetContext CurrentContext => Stage == SkillStage.Development ? Development : Live;

        private SkillSet(ManagementApi api, IEnumerable<SkillSummary> summaries, SkillSetOptions options)
        {
            Options = options ?? new SkillSetOptions();

            foreach (var summary in summaries)
            {
                if (summary.Stage == SkillStage.Development)
                {
                    Development = new SkillSetContext(api, summary,Options);
                    Stage = SkillStage.Development;
                }
                else
                {
                    Live = new SkillSetContext(api, summary,Options);
                }
            }

            if (Live == null)
            {
                Live = SkillSetContext.Empty();
            }
        }

        public static IEnumerable<SkillSet> From(ManagementApi api, params SkillSummary[] summaries)
        {
            return From(api, null, summaries);
        }

        public static IEnumerable<SkillSet> From(ManagementApi api, SkillSetOptions options,params SkillSummary[] summaries)
        {
            var skillSetOptions = options ?? new SkillSetOptions();
            return summaries.GroupBy(s => s.SkillId).Select(g => new SkillSet(api, g, skillSetOptions));
        }
    }
}