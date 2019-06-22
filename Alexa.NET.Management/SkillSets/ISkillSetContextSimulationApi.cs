using System.Threading.Tasks;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContextSimulationApi
    {
        string Locale { get; }
        Task<SimulationResult> NewSession(string message);
        Task<SimulationResult> SendNextMessage(string message);
    }
}