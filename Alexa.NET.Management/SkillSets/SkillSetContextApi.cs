using System.ComponentModel;
using Alexa.NET.Management.Api;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextApi:ISkillSetContextApi
    {
        private ManagementApi _api;
        private SkillSetContext _context;

        public SkillSetContextApi(ManagementApi api, SkillSetContext context)
        {
            _api = api;
            _context = context;
        }

        public bool SimulationSupported => _context.Stage.HasValue && _context.Stage == SkillStage.Development;
        public ISkillSetContextSimulationApi Simulation(string locale)
        {
            if (!SimulationSupported)
            {
                throw new InvalidStageException("Simulation API must be run against the development stage");
            }
            return new SkillSetContextSimulationApi(_api,_context,locale);
        }
    }
}