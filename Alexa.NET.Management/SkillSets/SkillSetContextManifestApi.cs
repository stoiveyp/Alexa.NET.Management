using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Manifest;

namespace Alexa.NET.Management.SkillSets
{
    public class SkillSetContextManifestApi:ISkillSetContextManifestApi
    {
        private ManagementApi _api;
        private SkillSetLocale _locale;

        public SkillSetContextManifestApi(ManagementApi api, SkillSetLocale locale)
        {
            _api = api;
            _locale = locale;
        }

        public async Task<SkillManifest> Get()
        {
            if (!_locale.Stage.Stage.HasValue)
            {
                return null;
            }

            var skill = await _api.Skills.Get(_locale.SkillID, _locale.Stage.Stage.Value);
            return skill.Manifest;
        }
    }
}
