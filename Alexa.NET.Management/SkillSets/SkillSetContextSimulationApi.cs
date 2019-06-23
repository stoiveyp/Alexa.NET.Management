using System.Threading.Tasks;
using Alexa.NET.Management.Skills;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextSimulationApi : ISkillSetContextSimulationApi
    {
        private readonly ManagementApi _api;
        private readonly SkillSetLocale _locale;

        public string Locale { get; }
        public SkillSetContextSimulationApi(ManagementApi api, SkillSetLocale locale)
        {
            _api = api;
            _locale = locale;
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
            var response = await _api.Skills.Simulate(_locale.SkillID, new SimulationRequest
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
                var secondResponse = await _api.Skills.SimulationResult(_locale.SkillID, response.Id);
                return secondResponse.Result;
            }

            return response.Result;
        }
    }
}