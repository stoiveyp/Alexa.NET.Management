using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Manifests;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        [Get("/skills/{skillId}")][Headers("Authorization: Bearer")]
        Task<SkillManifest> Get(string skillId);
    }
}
