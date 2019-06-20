namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContext:ISkillSetSummary
    {
        ISkillSetContextApi ContextApi { get; }

        string[] Locales { get;  }
    }
}