using System.Net.Http;
using System.Threading.Tasks;
using Alexa.NET.Management.Api;
using Alexa.NET.Management.Skills;
using Refit;

namespace Alexa.NET.Management.Internals
{
    public interface IClientSkillManagementApi
    {
        [Get("/v1/skills/{skillId}/status")]
        Task<SkillStatus> Status(string skillId, [Query]SkillResourceContainer container);

        [Get("/v1/skills/{skillId}/stages/{stage}/manifest")]
        Task<Skill> Get(string skillId, SkillStage stage);

        [Post("/v1/skills")]
        Task<SkillId> Create([Body] SkillCreateRequest request);

        [Put("/v1/skills/{skillId}/stages/{stage}/manifest")]
        Task<SkillId> Update(string skillId, SkillStage stage, [Body] Skill skill);

        [Post("/v1/skills/{skillId}/submit")]
        Task<HttpResponseMessage> Submit(string skillId, [Body]SubmitRequest request);

        [Delete("/v1/skills/{skillId}")]
        Task<HttpResponseMessage> Delete(string skillId);

        [Post("/v2/skills/{skillId}/stages/{stage}/invocations")]
        Task<InvocationResponse> Invoke(string skillId, SkillStage stage, [Body]InvocationRequest request);

        [Post("/v1/skills/{skillId}/withdraw")]
        Task Withdraw(string skillId, [Body]WithdrawalRequest request);

        [Post("/v1/skills/{skillId}/unpublish")]
        Task<UnpublishResponse> Unpublish(string skillId, [Body] UnpublishRequest request);

        [Post("/v2/skills/{skillId}/stages/{stage}/simulations")]
        Task<SimulationResponse> Simulate(string skillId, SkillStage stage, [Body] SimulationRequest request);

        [Get("/v2/skills/{skillId}/stages/{stage}/simulations/{simulationId}")]
        Task<SimulationResponse> SimulationResult(string skillId, SkillStage stage, string simulationId);

        [Get("/v1/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId);

        [Get("/v1/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, [Query]SkillIdContainer container);

        [Get("/v1/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, int maxResults);

        [Get("/v1/skills?vendorId={vendorId}")]
        Task<SkillListResponse> List(string vendorId, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId);

        [Get("/v1/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults);

        [Get("/v1/skills/{skillId}/certifications")]
        Task<CertificationListResponse> ListCertification(string skillId, int maxResults, string nextToken);

        [Get("/v1/skills/{skillId}/certifications/{certificationId}")]
        Task<Certification> Certification(string skillId, string certificationId);

        [Get("/v1/skills/{skillId}/certifications/{certificationId}")]
        Task<Certification> Certification(string skillId, string certificationId, [Header("Accept-Language")]string locale);

        [Post("/v1/skills/{skillId}/publications")]
        Task<HttpResponseMessage> Publish(string skillId);

        [Post("/v1/skills/{skillId}/publications")]
        Task<HttpResponseMessage> Publish(string skillId, [Body]PublishRequest request);
    }
}
