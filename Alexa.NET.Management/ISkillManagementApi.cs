using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization: Bearer")]
    public interface ISkillManagementApi
    {
        [Get("{skillId}")]
        Task<Skill> Get(string skillId);

        [Post("{vendorId}")]
        Task<SkillId> Create(string vendorId, [Body]Skill skill);

        [Put("{skillId}")]
        Task<SkillId> Update(string skillId, [Body] Skill skill);

        [Get("{skillId}/status")]
        Task<SkillStatus> Status(string skillId);
    }
}

