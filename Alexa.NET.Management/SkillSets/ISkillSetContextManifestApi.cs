using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alexa.NET.Management.Manifest;

namespace Alexa.NET.Management.SkillSets
{
    public interface ISkillSetContextManifestApi
    {
        Task<SkillManifest> Get();
    }
}
