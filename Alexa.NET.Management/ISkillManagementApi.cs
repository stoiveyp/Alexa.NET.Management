using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management
{
    public interface ISkillManagementApi
    {
        Task<SkillStatus> Status(string skillId, params string[] resource);
        Task<Skill> Get(string skillId, SkillStage stage);
        Task<SkillId> Create(string vendorId, [Body]Skill skill);

        Task<bool> Delete(string skillId);

        Task<SkillId> Update(string skillId, SkillStage stage, [Body] Skill skill);
        Task Submit(string skillId);
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);
        Task<UnpublishResponse> Unpublish(string skillId, UnpublishType type, UnpublishReason reason);
        Task<InvocationResponse> Invoke(string skillId, [Body]InvocationRequest request);
        Task<SimulationResponse> Simulate(string skillId, [Body] SimulationRequest request);
        Task<SimulationResponse> SimulationResult(string skillId, string simulationId);
        Task<SkillListResponse> List(string vendorId);
        Task<SkillListResponse> List(string vendorId, params string[] container);
        Task<SkillListResponse> List(string vendorId, int maxResults);
        Task<SkillListResponse> List(string vendorId, int maxResults, string nextToken);
        Task<CertificationListResponse> ListCertification(string skillId);
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults);
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults, string nextToken);
        Task<Certification> Certification(string skillId, string certificationId);
        Task<Certification> Certification(string skillId, string certificationId, string locale);
    }
}

