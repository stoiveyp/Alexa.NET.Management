using System.ComponentModel;
using Alexa.NET.Management.Api;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetLocaleApi: ISkillSetLocaleApi
    {
        private ManagementApi _api;
        private SkillSetLocale _locale;

        public SkillSetLocaleApi(SkillSetLocale skillSetLocale, ManagementApi api)
        {
            _api = api;
            _locale = skillSetLocale;
        }

        public bool SimulationSupported => _locale.Stage.Stage.HasValue && _locale.Stage.Stage == SkillStage.Development;
        public ISkillSetContextSimulationApi Simulation {
            get
            {
                if (!SimulationSupported)
                {
                    throw new InvalidStageException("Simulation API must be run against the development stage");
                }

                return new SkillSetContextSimulationApi(_api, _locale);
            }
        }

        public ISkillSetContextManifestApi Manifest => new SkillSetContextManifestApi(_api, _locale);
    }
}