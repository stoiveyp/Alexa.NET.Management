using System.Threading.Tasks;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContextSimulationApi
    {
        Task<SimulationResponse> NewSession(string message);
        Task<SimulationResponse> SendNextMessage(string message);

        Task<SimulationResult> WaitForResult(SimulationResponse response, int pollSeconds);
    }
}