using System.Threading.Tasks;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        [Get("{skillId}"), Headers("Authorization: Bearer")]
        Task<Skill> Get(string skillId);

        [Post("{vendorId}"), Headers("Authorization: Bearer")]
        Task<SkillId> Create(string vendorId, [Body]Skill skill);

        [Put("{skillId}"), Headers("Authorization: Bearer")]
        Task<SkillId> Update(string skillId, [Body] Skill skill);

        [Get("{skillId}/status"), Headers("Authorization: Bearer")]
        Task<SkillStatus> Status(string skillId);
    }
}

