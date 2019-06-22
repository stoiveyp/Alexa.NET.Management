using System.Threading.Tasks;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextSimulationApi : ISkillSetContextSimulationApi
    {
        private readonly ManagementApi _api;
        private readonly SkillSetContext _context;
        public string Locale { get; }
        public SkillSetContextSimulationApi(ManagementApi api, SkillSetContext context, string locale)
        {
            _api = api;
            _context = context;
            Locale = locale;
        }

        public Task<SimulationResult> NewSession(string message)
        {
            return SendMessage(message, SimulationSession.ForceNewSession);
        }

        public Task<SimulationResult> SendNextMessage(string message)
        {
            return SendMessage(message, SimulationSession.Default);
        }

        private async Task<SimulationResult> SendMessage(string message, SimulationSession session)
        {
            var response = await _api.Skills.Simulate(_context.ID, new SimulationRequest
            {
                Device = new SimulationRequestDevice
                {
                    Locale = Locale
                },
                Input = new SimulationRequestInput
                {
                    Content = message
                },
                Session = session
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