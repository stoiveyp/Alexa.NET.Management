using System.Collections.Generic;
using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSet
    {
        public SkillSummary Development { get; }
        public SkillSummary Live { get; }
        private SkillSet(IEnumerable<SkillSummary> summaries)
        {
            foreach (var summary in summaries)
            {
                if (summary.Stage == SkillStage.Development)
                {
                    Development = summary;
                }
                else
                {
                    Live = summary;
                }
            }
        }

        public string SkillId => Development.SkillId;

        public static IEnumerable<SkillSet> From(IEnumerable<SkillSummary> summaries)
        {
            return summaries.GroupBy(s => s.SkillId).Select(g => new SkillSet(g));
        }
    }
}