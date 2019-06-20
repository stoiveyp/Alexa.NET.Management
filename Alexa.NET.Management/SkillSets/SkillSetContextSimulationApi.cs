using System.Threading.Tasks;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextSimulationApi : ISkillSetContextSimulationApi
    {
        private ManagementApi _api;
        private SkillSetContext _context;
        public SkillSetContextSimulationApi(ManagementApi api, SkillSetContext context)
        {
            _api = api;
            _context = context;
        }

        private string SessionId { get; set; }

        Task<SimulationResult> NewSession(string locale, string message)
        {
            return SendMessage(locale, message, SimulationSession.ForceNewSession);
        }

        Task<SimulationResult> SendNextMessage(string locale, string message)
        {
            return SendMessage(locale, message, SimulationSession.Default);
        }

        private async Task<SimulationResult> SendMessage(string locale, string message, SimulationSession session)
        {
            var response = await _api.Skills.Simulate(_context.ID, new SimulationRequest
            {
                Device = new SimulationRequestDevice
                {
                    Locale = locale
                },
                Input = new SimulationRequestInput
                {
                    Content = message
                },
                Session = SimulationSession.ForceNewSession
            });

            if (response.Status == InvocationStatus.InProgress)
            {
                var secondResponse = await _api.Skills.SimulationResult(_context.ID, response.Id);
                return secondResponse.Result;
            }

            return response.Result;
        }
    }
}