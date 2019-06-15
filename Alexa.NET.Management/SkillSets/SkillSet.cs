using System;
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

        public SkillSetOptions Options { get; }

        public string Name => Options.GetKeyByPreferredLocale(Development.NameByLocale,d => d.First().Value);


        private SkillSet(IEnumerable<SkillSummary> summaries, SkillSetOptions options)
        {
            Options = options ?? new SkillSetOptions();

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

        public static IEnumerable<SkillSet> From(params SkillSummary[] summaries)
        {
            return From(null, summaries);
        }

        public static IEnumerable<SkillSet> From(SkillSetOptions options,params SkillSummary[] summaries)
        {
            var skillSetOptions = options ?? new SkillSetOptions();
            return summaries.GroupBy(s => s.SkillId).Select(g => new SkillSet(g, skillSetOptions));
        }
    }

    public class SkillSetOptions
    {
        public SkillSetOptions()
        {
            PreferredLocales = new[] {"en-US"};
        }

        public string[] PreferredLocales { get; set; }

        public T GetKeyByPreferredLocale<T>(Dictionary<string, T> set, Func<Dictionary<string,T>,T> defaultLocale) where T:class
        {
            var preferred = GetByPreferredLocale(set, (d, l) => d.ContainsKey(l) ? d[l] : null);
            return preferred ?? defaultLocale(set);
        }

        public T GetByPreferredLocale<TSet, T>(TSet set, Func<TSet, string, T> getByLocale)
        {
            return PreferredLocales.Select(l => getByLocale(set, l)).FirstOrDefault(r => r != null);
        }
    }
}