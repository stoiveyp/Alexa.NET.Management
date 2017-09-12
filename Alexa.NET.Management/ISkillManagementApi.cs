using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management
{
    [Headers("Authorization: Bearer")]
    public interface ISkillManagementApi
    {
        [Get("skills/{skillId}")]
        Task<Skill> Get(string skillId);

        [Post("skills/{vendorId}")]
        Task<SkillId> Create(string vendorId, [Body]Skill skill);

        [Put("skills/{skillId}")]
        Task<SkillId> Update(string skillId, [Body] Skill skill);

        [Get("skills/{skillId}/status")]
        Task<SkillStatus> Status(string skillId);

        [Post("skills/{skillId}/submit")]
        Task Submit(string skillId);

        [Post("skills/{skillId}/withdraw")]
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);

        [Post("skills/{skillId}/invocations")]
        Task<InvocationResponse> Invoke(string skillId, [Body]InvocationRequest request);
    }
}

