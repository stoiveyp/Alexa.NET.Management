using System.Linq;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetStage: ISkillSetStage
    {
        public SkillSetStage(ManagementApi api, SkillSummary summary, SkillSetOptions options)
        {
            Summary = summary;
            Options = options;
            Locales = Summary?.NameByLocale?.Keys.OrderBy(l => l,options).Select(l => new SkillSetLocale(api, this, l)).ToArray();
        }

        public string ID => Summary == null ? string.Empty : Summary.SkillId;
        public string Name => Summary == null ? string.Empty : Options.GetKeyByPreferredLocale(Summary.NameByLocale, s => s.First().Value);

        public SkillStage? Stage => Summary?.Stage;

        public SkillSetOptions Options { get; set; }

        public SkillSummary Summary { get; set; }

        public SkillSetLocale[] Locales { get; }

        public static ISkillSetStage Empty()
        {
            return new SkillSetStage(null, null,null);
        }
    }
}