using System;
using System.Threading.Tasks;
using Alexa.NET.Management.Manifest;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        [Get("/{skillId}")][Headers("Authorization: Bearer")]
        Task<SkillManifest> Get(string skillId);
    }
}
