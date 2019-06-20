namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContextApi
    {
        ISkillSetContextSimulationApi Simulation { get; }
    }
}