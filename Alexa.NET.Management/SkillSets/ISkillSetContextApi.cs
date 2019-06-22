namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContextApi
    {
        bool SimulationSupported { get; }
        ISkillSetContextSimulationApi Simulation(string locale);
    }
}