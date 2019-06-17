namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContext:ISkillSetSummary
    {
        ISkillSetApi Api { get; }
    }
}