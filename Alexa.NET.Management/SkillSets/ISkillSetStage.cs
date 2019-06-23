namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetStage:ISkillSetSummary
    {
        SkillSetLocale[] Locales { get;  }
    }
}