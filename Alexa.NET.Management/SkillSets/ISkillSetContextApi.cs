namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetLocaleApi
    {
        bool SimulationSupported { get; }
        ISkillSetContextSimulationApi Simulation { get; }
    }
}