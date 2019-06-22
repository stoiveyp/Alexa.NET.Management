namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContext:ISkillSetSummary
    {
        ISkillSetContextApi Api { get; }

        string[] Locales { get;  }
    }
}